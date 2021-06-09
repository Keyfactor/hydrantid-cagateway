# IO.Swagger.Api.CertificatesApi

All URIs are relative to *https://acm-stage.hydrantid.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CertificatesIdDerGet**](CertificatesApi.md#certificatesidderget) | **GET** /certificates/{id}/der | Download DER format certificate
[**CertificatesIdGet**](CertificatesApi.md#certificatesidget) | **GET** /certificates/{id} | Get a specific certificate
[**CertificatesIdPatch**](CertificatesApi.md#certificatesidpatch) | **PATCH** /certificates/{id} | Revoke a certificate given a certificate id
[**CertificatesIdPemGet**](CertificatesApi.md#certificatesidpemget) | **GET** /certificates/{id}/pem | Download PEM format certificate
[**CertificatesIdStatusGet**](CertificatesApi.md#certificatesidstatusget) | **GET** /certificates/{id}/status | Get certificate status
[**CertificatesPost**](CertificatesApi.md#certificatespost) | **POST** /certificates | Get Certificates
[**CertificatesSerialNumberPatch**](CertificatesApi.md#certificatesserialnumberpatch) | **PATCH** /certificates/{serialNumber} | Revoke a certificate given a serialNumber and issuerDN

<a name="certificatesidderget"></a>
# **CertificatesIdDerGet**
> byte[] CertificatesIdDerGet (Guid? id, bool? chain = null)

Download DER format certificate

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesIdDerGetExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var id = new Guid?(); // Guid? | Certificate ID
            var chain = true;  // bool? | Include Chain (optional) 

            try
            {
                // Download DER format certificate
                byte[] result = apiInstance.CertificatesIdDerGet(id, chain);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesIdDerGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Certificate ID | 
 **chain** | **bool?**| Include Chain | [optional] 

### Return type

**byte[]**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/pkix-cert

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatesidget"></a>
# **CertificatesIdGet**
> Certificate CertificatesIdGet (Guid? id)

Get a specific certificate

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesIdGetExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var id = new Guid?(); // Guid? | Certificate ID

            try
            {
                // Get a specific certificate
                Certificate result = apiInstance.CertificatesIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Certificate ID | 

### Return type

[**Certificate**](Certificate.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatesidpatch"></a>
# **CertificatesIdPatch**
> CertificateStatus CertificatesIdPatch (RevokeCertificateReason body, string id)

Revoke a certificate given a certificate id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesIdPatchExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var body = new RevokeCertificateReason(); // RevokeCertificateReason | Revocation reason.
            var id = id_example;  // string | Certificate id

            try
            {
                // Revoke a certificate given a certificate id
                CertificateStatus result = apiInstance.CertificatesIdPatch(body, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesIdPatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RevokeCertificateReason**](RevokeCertificateReason.md)| Revocation reason. | 
 **id** | **string**| Certificate id | 

### Return type

[**CertificateStatus**](CertificateStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatesidpemget"></a>
# **CertificatesIdPemGet**
> byte[] CertificatesIdPemGet (Guid? id, bool? chain = null)

Download PEM format certificate

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesIdPemGetExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var id = new Guid?(); // Guid? | Certificate ID
            var chain = true;  // bool? | Include Chain (optional) 

            try
            {
                // Download PEM format certificate
                byte[] result = apiInstance.CertificatesIdPemGet(id, chain);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesIdPemGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Certificate ID | 
 **chain** | **bool?**| Include Chain | [optional] 

### Return type

**byte[]**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/x-pem-file

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatesidstatusget"></a>
# **CertificatesIdStatusGet**
> CertificateStatus CertificatesIdStatusGet (string id)

Get certificate status

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesIdStatusGetExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var id = id_example;  // string | Certificate ID

            try
            {
                // Get certificate status
                CertificateStatus result = apiInstance.CertificatesIdStatusGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesIdStatusGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Certificate ID | 

### Return type

[**CertificateStatus**](CertificateStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatespost"></a>
# **CertificatesPost**
> GetCertificatesResponse CertificatesPost (GetCertificatesPayload body = null)

Get Certificates

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesPostExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var body = new GetCertificatesPayload(); // GetCertificatesPayload | Filter Certificates (optional) 

            try
            {
                // Get Certificates
                GetCertificatesResponse result = apiInstance.CertificatesPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**GetCertificatesPayload**](GetCertificatesPayload.md)| Filter Certificates | [optional] 

### Return type

[**GetCertificatesResponse**](GetCertificatesResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="certificatesserialnumberpatch"></a>
# **CertificatesSerialNumberPatch**
> CertificateStatus CertificatesSerialNumberPatch (RevokeCertificateReasonIssuerDN body, string serialNumber)

Revoke a certificate given a serialNumber and issuerDN

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CertificatesSerialNumberPatchExample
    {
        public void main()
        {
            var apiInstance = new CertificatesApi();
            var body = new RevokeCertificateReasonIssuerDN(); // RevokeCertificateReasonIssuerDN | Revocation reason and issuer DN
            var serialNumber = serialNumber_example;  // string | Serial number in hexadecimal format.

            try
            {
                // Revoke a certificate given a serialNumber and issuerDN
                CertificateStatus result = apiInstance.CertificatesSerialNumberPatch(body, serialNumber);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificatesApi.CertificatesSerialNumberPatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RevokeCertificateReasonIssuerDN**](RevokeCertificateReasonIssuerDN.md)| Revocation reason and issuer DN | 
 **serialNumber** | **string**| Serial number in hexadecimal format. | 

### Return type

[**CertificateStatus**](CertificateStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
