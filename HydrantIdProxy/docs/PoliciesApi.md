# IO.Swagger.Api.PoliciesApi

All URIs are relative to *https://acm-stage.hydrantid.com/api/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PoliciesGet**](PoliciesApi.md#policiesget) | **GET** /policies | Get all policies
[**PoliciesIdGet**](PoliciesApi.md#policiesidget) | **GET** /policies/{id} | Get a specific policy
[**PoliciesIdPut**](PoliciesApi.md#policiesidput) | **PUT** /policies/{id} | Update a policy with preview changes

<a name="policiesget"></a>
# **PoliciesGet**
> List<Policy> PoliciesGet (string imported = null)

Get all policies

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesGetExample
    {
        public void main()
        {
            var apiInstance = new PoliciesApi();
            var imported = imported_example;  // string | Load imported policies (type = IMPORTED) - true: include imported, false: exclude imported, only: only imported (optional) 

            try
            {
                // Get all policies
                List&lt;Policy&gt; result = apiInstance.PoliciesGet(imported);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imported** | **string**| Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported, only: only imported | [optional] 

### Return type

[**List<Policy>**](Policy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="policiesidget"></a>
# **PoliciesIdGet**
> Policy PoliciesIdGet (Guid? id)

Get a specific policy

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesIdGetExample
    {
        public void main()
        {
            var apiInstance = new PoliciesApi();
            var id = new Guid?(); // Guid? | Policy id

            try
            {
                // Get a specific policy
                Policy result = apiInstance.PoliciesIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**Guid?**](Guid?.md)| Policy id | 

### Return type

[**Policy**](Policy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="policiesidput"></a>
# **PoliciesIdPut**
> Policy PoliciesIdPut (string id, Policy body = null, string commit = null)

Update a policy with preview changes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesIdPutExample
    {
        public void main()
        {
            var apiInstance = new PoliciesApi();
            var id = id_example;  // string | Policy id
            var body = new Policy(); // Policy |  (optional) 
            var commit = commit_example;  // string | if commit=true then the policy will be updated (optional) 

            try
            {
                // Update a policy with preview changes
                Policy result = apiInstance.PoliciesIdPut(id, body, commit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Policy id | 
 **body** | [**Policy**](Policy.md)|  | [optional] 
 **commit** | **string**| if commit&#x3D;true then the policy will be updated | [optional] 

### Return type

[**Policy**](Policy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
