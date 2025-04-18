// Copyright 2025 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsSubjectAltNames : IPolicyDetailsSubjectAltNames
    {
        [JsonConverter(typeof(TagEnumConverter))]
        public enum TagEnum
        {
            [EnumMember(Value = "DNSNAME")] DnsName = 1,

            [EnumMember(Value = "IPADDRESS")] IpAddress = 2,

            [EnumMember(Value = "RFC822NAME")] Rfc822Name = 3,

            [EnumMember(Value = "UPN")] Upn = 4
        }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public TagEnum? Tag { get;set; }
        
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get;set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get;set; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get;set; }

        [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultValue { get;set; }

    }
}