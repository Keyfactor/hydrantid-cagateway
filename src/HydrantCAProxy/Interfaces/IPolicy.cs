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
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicy
    {
        Guid? Id { get;set; }
        string Name { get;set; }
        int? ApiId { get;set; }
        PolicyDetails Details { get;set; }
        PolicyEnabled Enabled { get;set; }
        Guid? OrganizationId { get;set; }
        Guid? CertificateAuthorityId { get;set; }
    }
}