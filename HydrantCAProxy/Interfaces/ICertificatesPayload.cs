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
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesPayload
    {
        string CommonName { get;set; }
        string Serial { get;set; }
        DateTime? NotBefore { get;set; }
        DateTime? NotAfter { get;set; }
        bool? Expired { get;set; }
        RevocationStatusEnum Status { get;set; }
        Guid? Account { get;set; }
        Guid? Organization { get;set; }
        Guid? Policy { get;set; }
        int? Limit { get;set; }
        int? Offset { get;set; }
        string SortType { get;set; }
        SortDirectionEnum SortDirection { get;set; }
        bool? Pem { get;set; }
    }
}