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
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificate
    {
        Guid? Id { get;set; }
        string Serial { get;set; }
        string CommonName { get;set; }
        string SubjectDn { get;set; }
        string IssuerDn { get;set; }
        DateTime? NotBefore { get;set; }
        DateTime? NotAfter { get;set; }
        string SignatureAlgorithm { get;set; }
        RevocationStatusEnum RevocationStatus { get;set; }
        int? RevocationReason { get;set; }
        DateTime? RevocationDate { get;set; }
        string Pem { get;set; }
        bool? Imported { get;set; }
        DateTime? CreatedAt { get;set; }
        List<string> SaNs { get;set; }
        CertRequestPolicy Policy { get;set; }
        CertificateUser User { get;set; }
        CertRequestPolicy Account { get;set; }
        CertRequestPolicy Organization { get;set; }
        List<string> ExpiryNotifications { get;set; }
    }
}