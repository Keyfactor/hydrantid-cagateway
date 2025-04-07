// Copyright 2025 Keyfactor                                                   
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
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestStatus : ICertRequestStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevocationStatusEnum
        {
            [EnumMember(Value = "VALID")] Valid = 1,

            [EnumMember(Value = "PENDING")] Pending = 2,

            [EnumMember(Value = "IN_PROCESS")] InProcess = 3,

            [EnumMember(Value = "REVOKED")] Revoked = 4,

            [EnumMember(Value = "FAILED")] Failed = 5
        }

        [JsonProperty("revocationStatus", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationStatusEnum? RevocationStatus { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("issuanceStatus", NullValueHandling = NullValueHandling.Ignore)]
        public IssuanceStatus IssuanceStatus { get; set; }

        [JsonProperty("issuanceStatusDetails", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> IssuanceStatusDetails { get; set; }

        [JsonProperty("certificateId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? CertificateId { get; set; }
    }
}