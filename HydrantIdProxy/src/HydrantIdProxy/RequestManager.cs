// Copyright 2023 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using System;
using System.Collections.Generic;
using System.IO;
using CAProxy.AnyGateway.Models;
using CSS.Common.Logging;
using CSS.PKI;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Keyfactor.HydrantId.Exceptions;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;

namespace Keyfactor.HydrantId
{
    public class RequestManager : LoggingClientBase
    {
        public int GetMapReturnStatus(RevocationStatusEnum hydrantIdStatus)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                PKIConstants.Microsoft.RequestDisposition returnStatus;
                Logger.Trace($"hydrantIdStatus: {hydrantIdStatus}");
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
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                return Convert.ToInt32(returnStatus);
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetMapReturnStatus: {e.Message}");
                throw;
            }
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
                Logger.Error($"Error Occured in RequestManager.GetMapRevokeReasons: {e.Message}");
                throw;
            }
        }

        public RevokeCertificateReason GetRevokeRequest(RevocationReasons reason)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                return new RevokeCertificateReason
                {
                    Reason = reason
                };
            }

            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetRevokeRequest: {e.Message}");
                throw;
            }
        }

        public CertificatesPayload GetCertificatesListRequest(int offset,int limit)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                return new CertificatesPayload
                {
                    Limit = limit,
                    Offset = offset,
                    Status = 0,
                    Expired = true
                };
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetCertificatesListRequest: {e.Message}");
                throw;
            }
        }

        public CertRequestBody GetEnrollmentRequest(Guid? policyId,EnrollmentProductInfo productInfo, string csr, Dictionary<string, string[]> san)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                if (san.ContainsKey("dns"))
                {
                    return new CertRequestBody
                    {
                        Policy = policyId,
                        Csr = csr,
                        DnComponents = GetDnComponentsRequest(csr),
                        SubjectAltNames = GetSansRequest(san),
                        Validity = GetValidity(productInfo.ProductParameters["ValidityPeriod"],Convert.ToInt16(productInfo.ProductParameters["ValidityUnits"]))
                    };
                }

                return new CertRequestBody
                {
                    Policy = policyId,
                    Csr = csr,
                    DnComponents = GetDnComponentsRequest(csr),
                    Validity=GetValidity(productInfo.ProductParameters["ValidityPeriod"], Convert.ToInt16(productInfo.ProductParameters["ValidityUnits"]))
                };
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetEnrollmentRequest: {e.Message}");
                throw;
            }
        }

        public RenewalRequest GetRenewalRequest(string csr, bool reuseCsr)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                return new RenewalRequest
                {
                    Csr = csr,
                    ReuseCsr = reuseCsr
                };
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetRenewalRequest: {e.Message}");
                throw;
            }
        }

        private CertRequestBodyValidity GetValidity(string period,int units)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
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
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetValidity: {e.Message}");
                throw;
            }
        }

        public CertRequestBodySubjectAltNames GetSansRequest(Dictionary<string, string[]> sans)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var san = new CertRequestBodySubjectAltNames();
                List<string> dnsNames = new List<string>();
                foreach (var v in sans["dns"])
                {
                    dnsNames.Add(v);
                }
                san.Dnsname=dnsNames;
                return san;
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetSansRequest: {e.Message}");
                throw;
            }
        }

        public EnrollmentResult
            GetEnrollmentResult(
                ICertificate enrollmentResult, CAConnectorCertificate cert)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                if (enrollmentResult==null)
                {
                    return new EnrollmentResult
                    {
                        Status = 30, //failure
                        StatusMessage = $"Enrollment Failed with could not get the certificate from the request tracking id"
                    };
                }

                if (!enrollmentResult.Id.HasValue)
                {
                    return new EnrollmentResult
                    {
                        Status = 30, //failure
                        StatusMessage = $"Enrollment Failed with could not get the certificate from the request tracking id"
                    };
                }

                if (enrollmentResult.Id.HasValue)
                {
                    return new EnrollmentResult
                    {
                        Status = (int)PKIConstants.Microsoft.RequestDisposition.ISSUED, //success
                        CARequestID = enrollmentResult.Id.ToString(),
                        Certificate = cert.Certificate,
                        StatusMessage = $"Order Successfully Created With Product {cert.ProductID}"
                    };
                }

                return null;
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetEnrollmentResult: {e.Message}");
                throw;
            }
        }

        public static Func<string, string> Pemify = ss =>
    ss.Length <= 64 ? ss : ss.Substring(0, 64) + "\n" + Pemify(ss.Substring(64));

        public CertRequestBodyDnComponents GetDnComponentsRequest(string csr)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var c = String.Empty;
                var o = String.Empty;
                var cn = string.Empty;
                var l = string.Empty;
                var st = string.Empty;
                var ou = string.Empty;

                Logger.Trace($"CSR: {csr}");
                var cert = "-----BEGIN CERTIFICATE REQUEST-----\r\n";
                cert = cert + Pemify(csr);
                cert = cert + "\r\n-----END CERTIFICATE REQUEST-----";
                Logger.Trace($"cert: {cert}");

                var reader = new PemReader(new StringReader(cert));
                if (reader.ReadObject() is Pkcs10CertificationRequest req)
                {
                    var info = req.GetCertificationRequestInfo();
                    Logger.Trace($"subject: {info.Subject}");

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
            catch (Exception e)
            {
                Logger.Error($"Error Occured in RequestManager.GetDnComponentsRequest: {e.Message}");
                throw;
            }
        }
    }
}

