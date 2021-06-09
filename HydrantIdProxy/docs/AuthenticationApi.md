# IO.Swagger.Api.AuthenticationApi

All URIs are relative to *https://acm-stage.hydrantid.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**HawkGet**](AuthenticationApi.md#hawkget) | **GET** /hawk | Get all HAWK Credentials associated with the current user user
[**HawkIdDelete**](AuthenticationApi.md#hawkiddelete) | **DELETE** /hawk/{id} | Delete a specific HAWK credential
[**HawkIdGet**](AuthenticationApi.md#hawkidget) | **GET** /hawk/{id} | Get a specific HAWK Credential
[**HawkIdPatch**](AuthenticationApi.md#hawkidpatch) | **PATCH** /hawk/{id} | Add/update a comment for a specific HAWK credential.
[**HawkIdPut**](AuthenticationApi.md#hawkidput) | **PUT** /hawk/{id} | Create a new secret for a specific HAWK credential.
[**HawkPost**](AuthenticationApi.md#hawkpost) | **POST** /hawk | Create a new HAWK Credential for the current user

<a name="hawkget"></a>
# **HawkGet**
> List<HawkCredential> HawkGet ()

Get all HAWK Credentials associated with the current user user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkGetExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();

            try
            {
                // Get all HAWK Credentials associated with the current user user
                List&lt;HawkCredential&gt; result = apiInstance.HawkGet();
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

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<HawkCredential>**](HawkCredential.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="hawkiddelete"></a>
# **HawkIdDelete**
> HawkCredentialDeleteResults HawkIdDelete (string id)

Delete a specific HAWK credential

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkIdDeleteExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var id = id_example;  // string | Identifier of HAWK credential to delete

            try
            {
                // Delete a specific HAWK credential
                HawkCredentialDeleteResults result = apiInstance.HawkIdDelete(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Identifier of HAWK credential to delete | 

### Return type

[**HawkCredentialDeleteResults**](HawkCredentialDeleteResults.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="hawkidget"></a>
# **HawkIdGet**
> HawkCredential HawkIdGet (string id)

Get a specific HAWK Credential

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkIdGetExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var id = id_example;  // string | Identifier of HAWK credential to retrieve

            try
            {
                // Get a specific HAWK Credential
                HawkCredential result = apiInstance.HawkIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Identifier of HAWK credential to retrieve | 

### Return type

[**HawkCredential**](HawkCredential.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="hawkidpatch"></a>
# **HawkIdPatch**
> HawkCredential HawkIdPatch (string id, HawkCredentialComment body = null)

Add/update a comment for a specific HAWK credential.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkIdPatchExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var id = id_example;  // string | Identifier of HAWK credential to update comments
            var body = new HawkCredentialComment(); // HawkCredentialComment | Optional comment (max 255 characters) (optional) 

            try
            {
                // Add/update a comment for a specific HAWK credential.
                HawkCredential result = apiInstance.HawkIdPatch(id, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkIdPatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Identifier of HAWK credential to update comments | 
 **body** | [**HawkCredentialComment**](HawkCredentialComment.md)| Optional comment (max 255 characters) | [optional] 

### Return type

[**HawkCredential**](HawkCredential.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="hawkidput"></a>
# **HawkIdPut**
> HawkCredential HawkIdPut (string id, HawkCredentialComment body = null)

Create a new secret for a specific HAWK credential.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkIdPutExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var id = id_example;  // string | Identifier of HAWK credential to update
            var body = new HawkCredentialComment(); // HawkCredentialComment | Optional comment (max 255 characters) (optional) 

            try
            {
                // Create a new secret for a specific HAWK credential.
                HawkCredential result = apiInstance.HawkIdPut(id, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Identifier of HAWK credential to update | 
 **body** | [**HawkCredentialComment**](HawkCredentialComment.md)| Optional comment (max 255 characters) | [optional] 

### Return type

[**HawkCredential**](HawkCredential.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="hawkpost"></a>
# **HawkPost**
> HawkCredential HawkPost (HawkCredentialComments body = null)

Create a new HAWK Credential for the current user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class HawkPostExample
    {
        public void main()
        {
            var apiInstance = new AuthenticationApi();
            var body = new HawkCredentialComments(); // HawkCredentialComments | Optional comment (max 255 characters) (optional) 

            try
            {
                // Create a new HAWK Credential for the current user
                HawkCredential result = apiInstance.HawkPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthenticationApi.HawkPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**HawkCredentialComments**](HawkCredentialComments.md)| Optional comment (max 255 characters) | [optional] 

### Return type

[**HawkCredential**](HawkCredential.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
