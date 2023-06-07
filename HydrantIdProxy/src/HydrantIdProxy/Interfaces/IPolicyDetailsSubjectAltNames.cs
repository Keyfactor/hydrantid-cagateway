// Copyright 2023 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsSubjectAltNames
    {
        PolicyDetailsSubjectAltNames.TagEnum? Tag { get;set; }
        string Label { get;set; }
        bool? Required { get;set; }
        bool? Modifiable { get;set; }
        string DefaultValue { get;set; }
    }
}