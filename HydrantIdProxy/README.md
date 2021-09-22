# IO.Swagger - the C# library for the HydrantID Account Certificate Manager (ACM) API

HydrantID provides customers the ability to manage the lifecycle of PKI certificates via the web based ACM REST API service.  This document outlines the methods to control the generation, retrieval and revocation of certificates.  ACM groups methods into 3 categories when dealing with the certificate lifecycle:   * Policies   * Certificate Requests   * Certificates   ### Policies  Describes the required, optional and default value for data elements that make up a certificate request.  Includes:   * Subject DN components - CN, OU, O, C, etc.   * SAN elements - DNSName, IPAddress, RFC822Name, UPN, etc.   * Custom Extensions - X509v3 extensions included in the certificate, i.e. Microsoft Application Policies, Template Information, etc.   * Custom Fields - descriptive non-certificate attributes used by the customer for reporting/identification, i.e. Department, Charge code, etc.  ACTION | URI                                       | DESCRIPTION - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- GET    | /api/v2/policies                          | Retrieves all policies available to user GET    | /api/v2/policies/{policyId}               | Retrieves a given policy  ### Certificate Requests  Describes all requests to generate certificates.  After issued, links to a certificateId for operations on the actual certificate.  ACTION | URI                                       | DESCRIPTION - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- POST   | /api/v2/csr                               | Creates a new request, returning certRequestId GET    | /api/v2/csr/{certRequestId}               | Retrieves a given certRequest, including all details GET    | /api/v2/csr/{certRequestId}/status        | Retrieves issuance status of certRequest, including certificateId if issued  ### Certificates  Describes all certificates issued by the user or others the user has access to.  ACTION | URI                                       | DESCRIPTION - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- POST   | /api/v2/certificates                      | Retrieves all certificates available to user GET    | /api/v2/certificates/{certificateId}      | Retrieves a given certificate, including status & PEM format cert GET    | /api/v2/certificates/{certificateId}/der  | Retrieves a binary DER format certificate GET    | /api/v2/certificates/{certificateId}/pem  | Retrieves a PEM format certificate PATCH  | /api/v2/certificates/{certificateId}      | Revokes a given certificate, given a certificateId  PATCH  | /api/v2/certificates/{serialNumber}       | Revokes a given certificate, given a serialNumber and issuerDN GET    | /api/v2/certificates/{certificateId}/status | Retrieves current revocation status  ## Authentication  All REST methods are require authentication via the \"HTTP Holder-Of-Key Authentication Scheme\", known as \"Hawk Authentication\" (see <https://github.com/mozilla/hawk/blob/main/API.md> ).  Hawk is an HTTP authentication scheme providing mechanisms for making authenticated HTTP requests with partial cryptographic verification of the request and response, covering the HTTP method, request URI, host, and optionally the request payload.  With Hawk Auth, each user will be issued a two randomly generated strings by HydrantID - an ID that will appear in the request, as well as a key that will be used to sign the request.  Each REST method requires an `Authorization` header formatted as below:  ```http Authorization: Hawk id=\"<hawk id>\", ts=\"<timestamp in seconds>\", nonce=\"<random string>\", mac=\"<Base64 HMAC>\", hash=\"<SHA256 Hash>\" ```  Also, please note that any REST actions that require a payload (POST/PATCH, etc.) will require the \"hash\" element for payload validation - see [Payload Validation](https://github.com/mozilla/hawk/blob/main/API.md#payload-validation) for more information. Responses may contain a `Server-Authorization` header with a hash of the response payload - see [Response Payload Validation](https://github.com/mozilla/hawk/blob/main/API.md#response-payload-validation).  See the [Hawk Authentication](https://github.com/mozilla/hawk/blob/main/API.md#response-payload-validation) page on GitHub for links to  implementations in NodeJS, .Net, Ruby, Java, etc.  ACM provides REST API methods to manage Hawk credentials for a user. Each user account is allowed up to 5 sets of Hawk credentials to access the REST API.  It is recommended that users \"roll\" their credentials from the initial values set by HydrantID and on as  as needed basis for security. Optional comments can be added to credentials for descriptive purposes.  The following actions are available:  ACTION | URI                                       | DESCRIPTION - -- -- - | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- POST   | /api/v2/hawk                              | Creates a new request, returning certRequestId GET    | /api/v2/hawk                              | Retrieves all credentials associated with the current user GET    | /api/v2/hawk/{hawkId}                     | Retrieves a specific Hawk credential PUT    | /api/v2/hawk/{hawkId}                     | Rolls a credential by establishing a new secret key DELETE | /api/v2/hawk/{hawkId}                     | Disables and removes a credential   ## Certificate Request Pseudocode  Requesting a certificate will normally flow like this:  ``` Generate CSR  Submit Request via POST /api/v2/csr, returning certRequestId  While CertRequest issuanceStatus == APPROVAL_REQUIRED | IN_PROCESS | PENDING     Get CertRequest Status via GET /api/v2/csr/{certRequestId}/status  If issuanceStatus == ISSUED     Download PEM certificate via GET /api/v2/certificates/{certificateId} ```  Please contact HydrantID for sample code in various languages. 

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: 1.3.4
- SDK version: 1.0.0
- Build package: io.swagger.codegen.v3.generators.dotnet.CSharpClientCodegen

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.2.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
```
<a name="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out IO.Swagger.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();

            try
            {
                // Get all HAWK Credentials associated with the current user user
                List<HawkCredential> result = apiInstance.HawkGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkGet: " + e.Message );
            }
        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://acm-stage.hydrantid.com/api/v2*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AuthenticationApi* | [**HawkGet**](docs/AuthenticationApi.md#hawkget) | **GET** /hawk | Get all HAWK Credentials associated with the current user user
*AuthenticationApi* | [**HawkIdDelete**](docs/AuthenticationApi.md#hawkiddelete) | **DELETE** /hawk/{id} | Delete a specific HAWK credential
*AuthenticationApi* | [**HawkIdGet**](docs/AuthenticationApi.md#hawkidget) | **GET** /hawk/{id} | Get a specific HAWK Credential
*AuthenticationApi* | [**HawkIdPatch**](docs/AuthenticationApi.md#hawkidpatch) | **PATCH** /hawk/{id} | Add/update a comment for a specific HAWK credential.
*AuthenticationApi* | [**HawkIdPut**](docs/AuthenticationApi.md#hawkidput) | **PUT** /hawk/{id} | Create a new secret for a specific HAWK credential.
*AuthenticationApi* | [**HawkPost**](docs/AuthenticationApi.md#hawkpost) | **POST** /hawk | Create a new HAWK Credential for the current user
*CertificateRequestsApi* | [**CsrIdGet**](docs/CertificateRequestsApi.md#csridget) | **GET** /csr/{id} | Retrieves a given certRequest, including all details
*CertificateRequestsApi* | [**CsrIdStatusGet**](docs/CertificateRequestsApi.md#csridstatusget) | **GET** /csr/{id}/status | Retrieves issuance status of certRequest, including certificateId if issued
*CertificateRequestsApi* | [**CsrPost**](docs/CertificateRequestsApi.md#csrpost) | **POST** /csr | Create a certificate request
*CertificatesApi* | [**CertificatesIdDerGet**](docs/CertificatesApi.md#certificatesidderget) | **GET** /certificates/{id}/der | Download DER format certificate
*CertificatesApi* | [**CertificatesIdGet**](docs/CertificatesApi.md#certificatesidget) | **GET** /certificates/{id} | Get a specific certificate
*CertificatesApi* | [**CertificatesIdPatch**](docs/CertificatesApi.md#certificatesidpatch) | **PATCH** /certificates/{id} | Revoke a certificate given a certificate id
*CertificatesApi* | [**CertificatesIdPemGet**](docs/CertificatesApi.md#certificatesidpemget) | **GET** /certificates/{id}/pem | Download PEM format certificate
*CertificatesApi* | [**CertificatesIdStatusGet**](docs/CertificatesApi.md#certificatesidstatusget) | **GET** /certificates/{id}/status | Get certificate status
*CertificatesApi* | [**CertificatesPost**](docs/CertificatesApi.md#certificatespost) | **POST** /certificates | Get Certificates
*CertificatesApi* | [**CertificatesSerialNumberPatch**](docs/CertificatesApi.md#certificatesserialnumberpatch) | **PATCH** /certificates/{serialNumber} | Revoke a certificate given a serialNumber and issuerDN
*PoliciesApi* | [**PoliciesGet**](docs/PoliciesApi.md#policiesget) | **GET** /policies | Get all policies
*PoliciesApi* | [**PoliciesIdGet**](docs/PoliciesApi.md#policiesidget) | **GET** /policies/{id} | Get a specific policy
*PoliciesApi* | [**PoliciesIdPut**](docs/PoliciesApi.md#policiesidput) | **PUT** /policies/{id} | Update a policy with preview changes

<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.CertRequest](docs/CertRequest.md)
 - [Model.CertRequestBody](docs/CertRequestBody.md)
 - [Model.CertRequestBodyDnComponents](docs/CertRequestBodyDnComponents.md)
 - [Model.CertRequestBodySubjectAltNames](docs/CertRequestBodySubjectAltNames.md)
 - [Model.CertRequestBodyValidity](docs/CertRequestBodyValidity.md)
 - [Model.CertRequestPolicy](docs/CertRequestPolicy.md)
 - [Model.CertRequestStatus](docs/CertRequestStatus.md)
 - [Model.CertRequestUser](docs/CertRequestUser.md)
 - [Model.Certificate](docs/Certificate.md)
 - [Model.CertificateStatus](docs/CertificateStatus.md)
 - [Model.CertificateUser](docs/CertificateUser.md)
 - [Model.GetCertificatesPayload](docs/GetCertificatesPayload.md)
 - [Model.GetCertificatesResponse](docs/GetCertificatesResponse.md)
 - [Model.GetCertificatesResponseItem](docs/GetCertificatesResponseItem.md)
 - [Model.HawkCredential](docs/HawkCredential.md)
 - [Model.HawkCredentialComment](docs/HawkCredentialComment.md)
 - [Model.HawkCredentialComments](docs/HawkCredentialComments.md)
 - [Model.HawkCredentialDeleteResults](docs/HawkCredentialDeleteResults.md)
 - [Model.IssuanceStatus](docs/IssuanceStatus.md)
 - [Model.NameObject](docs/NameObject.md)
 - [Model.Policy](docs/Policy.md)
 - [Model.PolicyDetails](docs/PolicyDetails.md)
 - [Model.PolicyDetailsCustomExtensions](docs/PolicyDetailsCustomExtensions.md)
 - [Model.PolicyDetailsCustomFields](docs/PolicyDetailsCustomFields.md)
 - [Model.PolicyDetailsDnComponents](docs/PolicyDetailsDnComponents.md)
 - [Model.PolicyDetailsExpiryEmails](docs/PolicyDetailsExpiryEmails.md)
 - [Model.PolicyDetailsSubjectAltNames](docs/PolicyDetailsSubjectAltNames.md)
 - [Model.PolicyDetailsValidity](docs/PolicyDetailsValidity.md)
 - [Model.PolicyEnabled](docs/PolicyEnabled.md)
 - [Model.RevocationReasons](docs/RevocationReasons.md)
 - [Model.RevocationStatusEnum](docs/RevocationStatusEnum.md)
 - [Model.RevokeCertificateReason](docs/RevokeCertificateReason.md)
 - [Model.RevokeCertificateReasonIssuerDN](docs/RevokeCertificateReasonIssuerDN.md)
 - [Model.SortDirectionEnum](docs/SortDirectionEnum.md)

<a name="documentation-for-authorization"></a>
## Documentation for Authorization

All endpoints do not require authorization.
