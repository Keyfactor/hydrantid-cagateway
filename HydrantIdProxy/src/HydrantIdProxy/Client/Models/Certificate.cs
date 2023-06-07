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
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class Certificate : ICertificate
    {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("serial", NullValueHandling = NullValueHandling.Ignore)]
        public string Serial { get; set; }

        [JsonProperty("commonName", NullValueHandling = NullValueHandling.Ignore)]
        public string CommonName { get; set; }

        [JsonProperty("subjectDN", NullValueHandling = NullValueHandling.Ignore)]
        public string SubjectDn { get; set; }

        [JsonProperty("issuerDN", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerDn { get; set; }

        [JsonProperty("notBefore", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotBefore { get; set; }

        [JsonProperty("notAfter", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotAfter { get; set; }

        [JsonProperty("signatureAlgorithm", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureAlgorithm { get; set; }

        [JsonProperty("revocationStatus", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationStatusEnum RevocationStatus { get; set; }

        [JsonProperty("revocationReason", NullValueHandling = NullValueHandling.Ignore)]
        public int? RevocationReason { get; set; }

        [JsonProperty("revocationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RevocationDate { get; set; }

        [JsonProperty("pem", NullValueHandling = NullValueHandling.Ignore)]
        public string Pem { get; set; }

        [JsonProperty("imported", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Imported { get; set; }

        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("SANs", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SaNs { get; set; }

        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestPolicy Policy { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public CertificateUser User { get; set; }

        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestPolicy Account { get; set; }

        [JsonProperty("organization", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestPolicy Organization { get; set; }

        [JsonProperty("expiryNotifications", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExpiryNotifications { get; set; }

    }
}