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

        public RevocationReasons GetMapRevokeReasons(uint keyfactorRevokeReason)
        {

            try
            {
                RevocationReasons returnStatus = RevocationReasons.KeyCompromise;
                if (keyfactorRevokeReason == 1 | keyfactorRevokeReason == 3 | keyfactorRevokeReason == 4 | keyfactorRevokeReason == 5)
                {

                    switch (keyfactorRevokeReason)
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
                dnsNames.Add(v);
            }
            san.Dnsname=dnsNames;
            return san;
        }

        public EnrollmentResult
            GetEnrollmentResult(
                ICertRequestResult enrollmentResult)
        {
            if (enrollmentResult.RequestStatus == null && enrollmentResult.ErrorReturn?.Error.Length>0)
            {
                return new EnrollmentResult
                {
                    Status = 30, //failure
                    StatusMessage = $"Enrollment Failed with the following error: {enrollmentResult.ErrorReturn.Error}"
                };
            }

            if (enrollmentResult != null && enrollmentResult.RequestStatus.IssuanceStatus.Equals(IssuanceStatus.Pending))
            {
                return new EnrollmentResult
                {
                    Status = 13, //success
                    CARequestID = enrollmentResult.RequestStatus.Id,
                    StatusMessage =
                        $"Order Successfully Created With Order Number {enrollmentResult.RequestStatus.Id}"
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

