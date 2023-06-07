// Copyright 2023 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using System.Collections.Generic;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestBodyDnComponents : ICertRequestBodyDnComponents
    {
        [JsonProperty("CN", NullValueHandling = NullValueHandling.Ignore)]
        public string Cn { get; set; }

        [JsonProperty("OU", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ou { get; set; }

        [JsonProperty("O", NullValueHandling = NullValueHandling.Ignore)]
        public string O { get; set; }

        [JsonProperty("L", NullValueHandling = NullValueHandling.Ignore)]
        public string L { get; set; }

        [JsonProperty("ST", NullValueHandling = NullValueHandling.Ignore)]
        public string St { get; set; }

        [JsonProperty("C", NullValueHandling = NullValueHandling.Ignore)]
        public string C { get; set; }

        [JsonProperty("DC", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dc { get; set; }

    }
}