using System;
using System.Collections.Generic;
using System.IO;
using CAProxy.AnyGateway.Models;
using CSS.PKI;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Org.BouncyCastle.Pkcs;

namespace Keyfactor.HydrantId
{
    public class RequestManager
    {
        public int GetMapReturnStatus(RevocationStatusEnum hydrantIdStatus)
        {
            PKIConstants.Microsoft.RequestDisposition returnStatus;

            switch (hydrantIdStatus)
            {
                case RevocationStatusEnum.Valid:
                    returnStatus = PKIConstants.Microsoft.RequestDisposition.ISSUED;
                    break;
                case RevocationStatusEnum.Pending:
                    returnStatus = PKIConstants.Microsoft.RequestDisposition.PENDING;
                    break;
                case RevocationStatusEnum.Revoked:
                    returnStatus = PKIConstants.Microsoft.RequestDisposition.REVOKED;
                    break;
                default:
                    returnStatus = PKIConstants.Microsoft.RequestDisposition.UNKNOWN;
                    break;
            }

            return Convert.ToInt32(returnStatus);
        }

        public CertificatesPayload GetCertificatesListRequest(int offset,int limit)
        {
            return new CertificatesPayload
            {
                Limit= limit,
                Offset = offset
            };
        }

        public CertRequestBody GetEnrollmentRequest(Guid? policyId,EnrollmentProductInfo productInfo, string csr, Dictionary<string, string[]> san)
        {
            return new CertRequestBody
            {
                Policy = policyId,
                Csr = csr,
                DnComponents = GetDnComponentsRequest(csr),
                SubjectAltNames = GetSansRequest(san)
            };
        }

        public CertRequestBodySubjectAltNames GetSansRequest(Dictionary<string, string[]> sans)
        {
            var san = new CertRequestBodySubjectAltNames();

            foreach (var v in sans["dns"])
            {
                san.Dnsname.Add(v);
            }

            return san;
        }

        public EnrollmentResult
            GetEnrollmentResult(
                ICertRequestStatus enrollmentResult)
        {
            if (enrollmentResult != null && enrollmentResult.IssuanceStatus.Equals(RevocationStatusEnum.Failed))
            {
                return new EnrollmentResult
                {
                    Status = 30, //failure
                    StatusMessage = "Enrollment Failed"
                };
            }

            if (enrollmentResult != null && enrollmentResult.IssuanceStatus.Equals(RevocationStatusEnum.InProcess))
            {
                return new EnrollmentResult
                {
                    Status = 9, //success
                    StatusMessage =
                        $"Order Successfully Created With Order Number {enrollmentResult.Id}"
                };
            }

            return null;
        }

        public CertRequestBodyDnComponents GetDnComponentsRequest(string csr)
        {
            var c = String.Empty;
            var o = String.Empty;
            var cn = string.Empty;
            var l = string.Empty;
            var st = string.Empty;
            var ou = string.Empty;

            var reader = new Org.BouncyCastle.OpenSsl.PemReader(new StringReader(csr));
            if (reader.ReadObject() is Pkcs10CertificationRequest req)
            {
                var info = req.GetCertificationRequestInfo();
                Console.WriteLine(info.Subject);

                var array1 = info.Subject.ToString().Split(',');
                foreach (var x in array1)
                {
                    var itemArray = x.Split('=');

                    switch (itemArray[0].ToUpper())
                    {
                        case "C":
                            c = itemArray[1];
                            break;
                        case "O":
                            o = itemArray[1];
                            break;
                        case "CN":
                            cn = itemArray[1];
                            break;
                        case "OU":
                            ou = itemArray[1];
                            break;
                        case "ST":
                            st = itemArray[1];
                            break;
                        case "L":
                            l = itemArray[1];
                            break;
                    }
                }
            }

            return new CertRequestBodyDnComponents
            {
                Cn = cn,
                Ou = new List<string>{ou},
                O=o,
                L=l,
                St = st,
                C=c
            };
        }
    }
}

