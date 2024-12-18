
# HydrantId

HydrantId operates a PKI as a service platform for customers around the globe.  The AnyGateway solution for HydrantId is designed to allow Keyfactor Command the ability to: - Sync certificates issued from the CA - Request new certificates from the CA - Revoke certificates directly from Keyfactor Command -Renew or Reissue Certificates from the CA

#### Integration status: Production - Ready for use in production environments.

## About the Keyfactor AnyCA Gateway DCOM Connector

This repository contains an AnyCA Gateway Connector, which is a plugin to the Keyfactor AnyGateway. AnyCA Gateway Connectors allow Keyfactor Command to be used for inventory, issuance, and revocation of certificates from a third-party certificate authority.

## Support for HydrantId

HydrantId is supported by Keyfactor for Keyfactor customers. If you have a support issue, please open a support ticket via the Keyfactor Support Portal at https://support.keyfactor.com

###### To report a problem or suggest a new feature, use the **[Issues](../../issues)** tab. If you want to contribute actual bug fixes or proposed enhancements, use the **[Pull requests](../../pulls)** tab.

---


---





## Keyfactor AnyCA Gateway Framework Supported
The Keyfactor gateway framework implements common logic shared across various gateway implementations and handles communication with Keyfactor Command. The gateway framework hosts gateway implementations or plugins that understand how to communicate with specific CAs. This allows you to integrate your third-party CAs with Keyfactor Command such that they behave in a manner similar to the CAs natively supported by Keyfactor Command.




This gateway extension was compiled against version  of the AnyCA Gateway DCOM Framework.  You will need at least this version of the framework Installed. If you have a later AnyGateway Framework Installed you will probably need to add binding redirects in the CAProxyServer.exe.config file to make things work properly.


[Keyfactor CAGateway Install Guide](https://software.keyfactor.com/Guides/AnyGateway_Generic/Content/AnyGateway/Introduction.htm)



---


*** 
# Getting Started
## Standard Gateway Installation
To begin, you must have the CA Gateway Service 21.3.2 installed and operational before attempting to configure the HydrantId plugin. This integration was tested with Keyfactor 9.3.0.0.
To install the gateway follow these instructions.

1) Gateway Server - run the installation .msi obtained from Keyfactor

2) Gateway Server - If you have the rights to install the database (usually in a Non SQL PAAS Environment) Using Powershell, run the following command to create the gateway database.

   **SQL Server Windows Auth**
    ```
    %InstallLocation%\DatabaseManagementConsole.exe create -s [database server name] -d [database name]
    ```
   Note if you are using SQL Authentication, then you need to run
   
   **SQL Server SQL Authentication**

   ```
   %InstallLocation%\DatabaseManagementConsole.exe create -s [database server name] -d [database name] -u [sql user] -p [sql password]
   ```

   If you do **not** have rights to created the database then have the database created ahead of time by the support team and just populate the database

   ## Populate commands below

   **Windows Authentication**

   ```
   %InstallLocation%\DatabaseManagementConsole.exe populate -s [database server name] -d [database name]
   ```

   **SQL Server SQL Authentication** 

   ```
   %InstallLocation%\DatabaseManagementConsole.exe populate -s [database server name] -d [database name] -u [sql user] -p [sql password]
   ```

3) Gateway Server - run the following Powershell to import the Cmdlets

   C:\Program Files\Keyfactor\Keyfactor AnyGateway\ConfigurationCmdlets.dll (must be imported into Powershell)
   ```ps
   Import-Module C:\Program Files\Keyfactor\Keyfactor AnyGateway\ConfigurationCmdlets.dll
   ```

4) Gateway Server - Run the Following Powershell script to set the gateway encryption cert

   ### Set-KeyfactorGatewayEncryptionCert
   This cmdlet will generate a self-signed certificate used to encrypt the database connection string. It populates a registry value with the serial number of the certificate to be used. The certificate is stored in the LocalMachine Personal Store and the registry key populated is:

   ```HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\CertSvcProxy\Parameters\EncryptSerialNumber```
   No parameters are required to run this cmdlet.

5) Gateway Server - Run the following Powershell Script to Set the Database Connection

   ### Set-KeyfactorGatewayDatabaseConnection
   This cmdlet will set and encrypt the database connection string used by the AnyGateway service. 

   **Windows Authentication**
   ```ps
   Set-KeyfactorGatewayDatabaseConnection -Server [db server name] -Database [database name]
   ```

   **SQL Authentication**
   ```ps
   $KeyfactorCredentials = Get-Credentials
   Set-KeyfactorGatewayDatabaseConnection -Server [db server name] -Database [database name] -Account [$KeyfactorCredentials]
   ```
## Standard Gateway Configuration Finished
---


## HydrantId AnyGateway Specific Configuration
It is important to note that importing the HydrantId configuration into the CA Gateway after installing the binaries must be completed. Additionally, the CA Gateway service
must be running in order to succesfully import the configuation. When the CA Gateway service starts it will attempt to validate the connection information to 
the CA.  Without the imported configuration, the service will fail to start.

### Binary Installation

1) Get the Latest Zip File from [Here](https://github.com/Keyfactor/hydrantid-cagateway/releases/)
2) Gateway Server - Copy the HawkNet.dll, The HydrantIdProxy.dll and the HydrantIdProxy.dll.config to the location where the Gateway Framework was installed (usually C:\Program Files\Keyfactor\Keyfactor AnyGateway)

### Configuration Changes
1) Gateway Server - Edit the CAProxyServer.exe.config file and replace the line that says "NoOp" with the line below:
   ```
   <alias alias="CAConnector" type="Keyfactor.HydrantId.HydrantIdProxy, HydrantIdProxy"/>
   ```
2) Gateway Server - Install the Root HydrantId Certificate that was received from HydrantId

3) Gateway Server - Install the Intermediate HydrantId Certificate that was received from HydrantId

4) Gateway Server - Take the sample Config.json located [Here](https://github.com/Keyfactor/hydrantid-cagateway/raw/main/SampleConfig.json) and make the following modifications

- *Security Settings Modifications* (Swap this out for the typical Gateway Security Settings for Test or Prod)

```
  "Security": {
    "KEYFACTOR\\administrator": {
      "READ": "Allow",
      "ENROLL": "Allow",
      "OFFICER": "Allow",
      "ADMINISTRATOR": "Allow"
    },
    "KEYFACTOR\\SVC_AppPool": {
      "READ": "Allow",
      "ENROLL": "Allow",
      "OFFICER": "Allow",
      "ADMINISTRATOR": "Allow"
    },
    "KEYFACTOR\\SVC_TimerService": {
      "READ": "Allow",
      "ENROLL": "Allow",
      "OFFICER": "Allow",
      "ADMINISTRATOR": "Allow"
    }
```
- *Hydrant Environment Settings* (Modify these with the keys and Urls obtained from HydrantId)
```
  "CAConnection": {
    "HydrantIdBaseUrl": "https://acm-stage.hydrantid.com",
    "AuthId": "SomeAuthId",
    "AuthKey": "SomeAuthPassword",
    "TemplateSync": "On"
  }
```

- *Service Settings* (Modify these to be in accordance with Keyfactor Standard Gateway Production Settings)
```
  "ServiceSettings": {
    "ViewIdleMinutes": 1,
    "FullScanPeriodHours": 1,
    "PartialScanPeriodMinutes": 1
  }
```

5) Gateway Server - Save the newly modified config.json to the following location "C:\Program Files\Keyfactor\Keyfactor AnyGateway"

### Template Installation

The Template section will map the CA's products to an AD template.
* ```ProductID```
This is the ID of the HydrantId product to map to the specified template. If you don't know the available product IDs in your Hydrant account, put a placeholder value here and run the Set-KeyfactorGatewayConfig cmdlet according to the AnyGateway documentation. The list of available product IDs will be returned.
* ```ValidityPeriod```
REQUIRED: The period to use when requesting certs. It could be, Days, Months, Years depending on the Template.
* ```ValidityUnits```
REQUIRED: The numeric value corresponding to the ValidityPeriod. For years 1 would be 1 year, for days 7 would be 7 days.

 ```json
	"Templates": {
		"AutoEnrollment - RSA": {
			"ProductID": "AutoEnrollment - RSA",
			"Parameters": {
				"ValidityPeriod": "Years",
				"ValidityUnits": 1
			}
		},
		"AutoEnrollment - RSA - 7 Day": {
			"ProductID": "AutoEnrollment - RSA - 7 Day",
			"Parameters": {
				"ValidityPeriod": "Days",
				"ValidityUnits": 7
			}
		}
	}
 ```

### Certificate Authority Installation
1) Gateway Server - Start the Keyfactor Gateway Service
2) Run the set Gateway command similar to below
```ps
Set-KeyfactorGatewayConfig -LogicalName "HydrantId" -FilePath [path to json file] -PublishAd
```
3) Command Server - Import the certificate authority in Keyfactor Portal 


***

### License
[Apache](https://apache.org/licenses/LICENSE-2.0)


