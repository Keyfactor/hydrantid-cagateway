// Copyright 2023 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationReasons
    {
        [EnumMember(Value = "1")] KeyCompromise = 1,
        [EnumMember(Value = "3")] AffiliationChanged = 3,
        [EnumMember(Value = "4")] Superseded = 4,
        [EnumMember(Value = "5")] CessationOfOperation = 5
    }
}