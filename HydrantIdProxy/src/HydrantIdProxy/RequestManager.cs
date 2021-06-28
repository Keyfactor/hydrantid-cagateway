using System;
using System.Collections.Generic;
using System.IO;
using CAProxy.AnyGateway.Models;
using CSS.PKI;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Org.BouncyCastle.Pkcs;
using Keyfactor.HydrantId.Exceptions;

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

        public RevocationReasons GetMapRevokeReasons(uint KeyfactorRevokeReason)
        {

            try
            {
                RevocationReasons returnStatus = RevocationReasons.KeyCompromise;
                if (KeyfactorRevokeReason == 1 | KeyfactorRevokeReason == 3 | KeyfactorRevokeReason == 4 | KeyfactorRevokeReason == 5)
                {

                    switch (KeyfactorRevokeReason)
                    {
                        case 1:
                            returnStatus = RevocationReasons.KeyCompromise;
                            break;
                        case 3:
                            returnStatus = RevocationReasons.AffiliationChanged;
                            break;
                        case 4:
                            returnStatus = RevocationReasons.Superseded;
                            break;
                        case 5:
                            returnStatus = RevocationReasons.CessationOfOperation;
                            break;
                    }

                    return returnStatus;
                }

                throw new RevokeReasonNotSupportedException("This Revoke Reason is not Supported");

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public RevokeCertificateReason GetRevokeRequest(RevocationReasons reason)
        {
            return new RevokeCertificateReason
            {
                Reason = reason
            };
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
            if(san.ContainsKey("dns"))
            {

                return new CertRequestBody
                {
                    Policy = policyId,
                    Csr = csr,
                    DnComponents = GetDnComponentsRequest(csr),
                    SubjectAltNames = GetSansRequest(san),
                    Validity = GetValidity(productInfo.ProductParameters["Validity Period"],Convert.ToInt16(productInfo.ProductParameters["Validity Units"]))
                };
            }

            return new CertRequestBody
            {
                Policy = policyId,
                Csr = csr,
                DnComponents = GetDnComponentsRequest(csr),
                Validity=GetValidity(productInfo.ProductParameters["Validity Period"], Convert.ToInt16(productInfo.ProductParameters["Validity Units"]))
            };
        }

        private CertRequestBodyValidity GetValidity(string period,int units)
        {
            CertRequestBodyValidity validity = new CertRequestBodyValidity();
            switch(period)
            {
                case "Years":
                    validity.Years = units;
                    break;
                case "Months":
                    validity.Months = units;
                    break;
                case "Days":
                    validity.Days = units;
                    break;
            }
                        
            return validity;
        }

        public CertRequestBodySubjectAltNames GetSansRequest(Dictionary<string, string[]> sans)
        {
            var san = new CertRequestBodySubjectAltNames();
            List<string> dnsNames = new List<string>();
            foreach (var v in sans["dns"])
            {
                dnsNames.Add(v.ToString());
            }
            san.Dnsname=dnsNames;
            return san;
        }

        public EnrollmentResult
            GetEnrollmentResult(
                ICertRequestStatus enrollmentResult)
        {
            if (enrollmentResult != null && enrollmentResult.IssuanceStatus.Equals(IssuanceStatus.Failed))
            {
                return new EnrollmentResult
                {
                    Status = 30, //failure
                    StatusMessage = "Enrollment Failed"
                };
            }

            if (enrollmentResult != null && enrollmentResult.IssuanceStatus.Equals(IssuanceStatus.Pending))
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

        public static Func<string, string> Pemify = ss =>
    ss.Length <= 64 ? ss : ss.Substring(0, 64) + "\n" + Pemify(ss.Substring(64));

        public CertRequestBodyDnComponents GetDnComponentsRequest(string csr)
        {
            var c = String.Empty;
            var o = String.Empty;
            var cn = string.Empty;
            var l = string.Empty;
            var st = string.Empty;
            var ou = string.Empty;

            var cert = "-----BEGIN CERTIFICATE REQUEST-----\r\n";
            cert = cert + Pemify(csr);
            cert = cert + "\r\n-----END CERTIFICATE REQUEST-----";

            var reader = new Org.BouncyCastle.OpenSsl.PemReader(new StringReader(cert));
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

