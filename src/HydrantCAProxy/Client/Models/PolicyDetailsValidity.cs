// Copyright 2025 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsValidity : IPolicyDetailsValidity
    {
        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Years { get;set; }

        [JsonProperty("months", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Months { get;set; }

        [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Days { get;set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get;set; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get;set; }

    }
}