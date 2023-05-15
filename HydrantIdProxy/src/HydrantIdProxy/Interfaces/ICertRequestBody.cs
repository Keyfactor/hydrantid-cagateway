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

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBody
    {
        Guid? Policy { get;set; }
        string Csr { get;set; }
        CertRequestBodyValidity Validity { get;set; }
        CertRequestBodyDnComponents DnComponents { get;set; }
        CertRequestBodySubjectAltNames SubjectAltNames { get;set; }
        Dictionary<string, object> CustomFields { get;set; }
        Dictionary<string, object> CustomExtensions { get;set; }
        string Comment { get;set; }
        List<string> ExpiryEmails { get;set; }
        string ClearRemindersCertificateId { get;set; }
    }
}