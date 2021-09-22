# IO.Swagger.Model.Certificate
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **Guid?** |  | 
**Serial** | **string** |  | 
**CommonName** | **string** |  | 
**SubjectDN** | **string** |  | 
**IssuerDN** | **string** |  | 
**NotBefore** | **DateTime?** |  | 
**NotAfter** | **DateTime?** |  | 
**SignatureAlgorithm** | **string** |  | 
**RevocationStatus** | **RevocationStatusEnum** |  | 
**RevocationReason** | **int?** |  | 
**RevocationDate** | **DateTime?** |  | [optional] 
**Pem** | **string** |  | 
**Imported** | **bool?** |  | 
**CreatedAt** | **DateTime?** |  | 
**SANs** | **List&lt;string&gt;** |  | [optional] 
**Policy** | [**CertRequestPolicy**](CertRequestPolicy.md) |  | [optional] 
**User** | [**CertificateUser**](CertificateUser.md) |  | [optional] 
**Account** | [**CertRequestPolicy**](CertRequestPolicy.md) |  | [optional] 
**Organization** | [**CertRequestPolicy**](CertRequestPolicy.md) |  | [optional] 
**ExpiryNotifications** | **List&lt;string&gt;** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

