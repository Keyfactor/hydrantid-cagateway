# IO.Swagger.Model.GetCertificatesPayload
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CommonName** | **string** |  | [optional] 
**Serial** | **string** |  | [optional] 
**NotBefore** | **DateTime?** |  | [optional] 
**NotAfter** | **DateTime?** |  | [optional] 
**Expired** | **bool?** |  | [optional] [default to false]
**Status** | **RevocationStatusEnum** |  | [optional] 
**Account** | **Guid?** |  | [optional] 
**Organization** | **Guid?** |  | [optional] 
**Policy** | **Guid?** |  | [optional] 
**Limit** | **int?** |  | [optional] [default to 10]
**Offset** | **int?** |  | [optional] [default to 0]
**SortType** | **string** |  | [optional] 
**SortDirection** | **SortDirectionEnum** |  | [optional] 
**Pem** | **bool?** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

