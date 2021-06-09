# IO.Swagger.Api.CertificateRequestsApi

All URIs are relative to *https://acm-stage.hydrantid.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CsrIdGet**](CertificateRequestsApi.md#csridget) | **GET** /csr/{id} | Retrieves a given certRequest, including all details
[**CsrIdStatusGet**](CertificateRequestsApi.md#csridstatusget) | **GET** /csr/{id}/status | Retrieves issuance status of certRequest, including certificateId if issued
[**CsrPost**](CertificateRequestsApi.md#csrpost) | **POST** /csr | Create a certificate request

<a name="csridget"></a>
# **CsrIdGet**
> CertRequest CsrIdGet (Guid? id)

Retrieves a given certRequest, including all details

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CsrIdGetExample
    {
        public void main()
        {
            var apiInstance = new CertificateRequestsApi();
            var id = new Guid?(); // Guid? | Certificate Request ID

            try
            {
                // Retrieves a given certRequest, including all details
                CertRequest result = apiInstance.CsrIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificateRequestsApi.CsrIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Certificate Request ID | 

### Return type

[**CertRequest**](CertRequest.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="csridstatusget"></a>
# **CsrIdStatusGet**
> CertRequestStatus CsrIdStatusGet (Guid? id)

Retrieves issuance status of certRequest, including certificateId if issued

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CsrIdStatusGetExample
    {
        public void main()
        {
            var apiInstance = new CertificateRequestsApi();
            var id = new Guid?(); // Guid? | Certificate Request ID

            try
            {
                // Retrieves issuance status of certRequest, including certificateId if issued
                CertRequestStatus result = apiInstance.CsrIdStatusGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificateRequestsApi.CsrIdStatusGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Certificate Request ID | 

### Return type

[**CertRequestStatus**](CertRequestStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="csrpost"></a>
# **CsrPost**
> CertRequestStatus CsrPost (CertRequestBody body = null)

Create a certificate request

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CsrPostExample
    {
        public void main()
        {
            var apiInstance = new CertificateRequestsApi();
            var body = new CertRequestBody(); // CertRequestBody |  (optional) 

            try
            {
                // Create a certificate request
                CertRequestStatus result = apiInstance.CsrPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificateRequestsApi.CsrPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CertRequestBody**](CertRequestBody.md)|  | [optional] 

### Return type

[**CertRequestStatus**](CertRequestStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
