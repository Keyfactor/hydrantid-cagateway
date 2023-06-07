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
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestBody : ICertRequestBody
    {
        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Policy { get; set; }

        [JsonProperty("csr", NullValueHandling = NullValueHandling.Ignore)]
        public string Csr { get; set; }

        [JsonProperty("validity", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestBodyValidity Validity { get; set; }

        [JsonProperty("dnComponents", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestBodyDnComponents DnComponents { get; set; }

        [JsonProperty("subjectAltNames", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestBodySubjectAltNames SubjectAltNames { get; set; }

        [JsonProperty("customFields", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> CustomFields { get; set; }

        [JsonProperty("customExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> CustomExtensions { get; set; }

        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("expiryEmails", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExpiryEmails { get; set; }

        [JsonProperty("clearRemindersCertificateId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClearRemindersCertificateId { get; set; }
    }
}