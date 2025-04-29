<h1 align="center" style="border-bottom: none">
    HydrantId AnyCA Gateway REST Plugin
</h1>

<p align="center">
  <!-- Badges -->
<img src="https://img.shields.io/badge/integration_status-production-3D1973?style=flat-square" alt="Integration Status: production" />
<a href="https://github.com/Keyfactor/hydrantid-cagateway/releases"><img src="https://img.shields.io/github/v/release/Keyfactor/hydrantid-cagateway?style=flat-square" alt="Release" /></a>
<img src="https://img.shields.io/github/issues/Keyfactor/hydrantid-cagateway?style=flat-square" alt="Issues" />
<img src="https://img.shields.io/github/downloads/Keyfactor/hydrantid-cagateway/total?style=flat-square&label=downloads&color=28B905" alt="GitHub Downloads (all assets, all releases)" />
</p>

<p align="center">
  <!-- TOC -->
  <a href="#support">
    <b>Support</b>
  </a> 
  ·
  <a href="#requirements">
    <b>Requirements</b>
  </a>
  ·
  <a href="#installation">
    <b>Installation</b>
  </a>
  ·
  <a href="#license">
    <b>License</b>
  </a>
  ·
  <a href="https://github.com/orgs/Keyfactor/repositories?q=anycagateway">
    <b>Related Integrations</b>
  </a>
</p>


HydrantId operates a PKI as a service platform for customers around the globe. The AnyGateway solution for HydrantId is designed to allow Keyfactor Command:

* CA Sync:
    * Download all certificates issued by connected Enterprise tier CAs in HydrantId (full sync).
* Certificate enrollment for all published HydrantId Certificate SKUs:
    * Support certificate enrollment (new keys/certificate).
* Certificate revocation:
    * Request revocation of a previously issued certificate.

## Compatibility

The HydrantId AnyCA Gateway REST plugin is compatible with the Keyfactor AnyCA Gateway REST 24.2 and later.

## Support
The HydrantId AnyCA Gateway REST plugin is supported by Keyfactor for Keyfactor customers. If you have a support issue, please open a support ticket with your Keyfactor representative. If you have a support issue, please open a support ticket via the Keyfactor Support Portal at https://support.keyfactor.com. 

> To report a problem or suggest a new feature, use the **[Issues](../../issues)** tab. If you want to contribute actual bug fixes or proposed enhancements, use the **[Pull requests](../../pulls)** tab.

## Requirements

### 🔐 HydrantID API Key Setup Guide

This guide explains how to generate and use an API Key ID and Secret in HydrantID for authenticated API access.

---

#### 📍 Where to Find API Key Management

1. **Log in** to your HydrantID instance.
   - Example: https://acm-stage.hydrantid.com

2. Click your **user profile icon** (top right) and select **"Profile"**.

3. In the **Profile** page, scroll to the section labeled `API Keys`.

---

#### ➕ Add a New API Key

1. Click **"ADD API KEY"** (top right of the API Keys section).
2. A new API Key will be generated with:
   - A unique **API ID**
   - A **Secret API Key** — copy it immediately as it is only shown once.

---

#### 🧾 Notes on API Keys

- **ID** = what you'll pass in the HAWK `id` field
- **Key** = secret used to generate HAWK signature
- Each key shows `Created` and `Last Used` timestamps for traceability

---

#### 🔐 Using the API ID and Key with HAWK

HydrantID uses [HAWK Authentication](https://github.com/hueniverse/hawk) to secure its API.

##### Required Fields in Authorization Header:
```text
Hawk id="API_ID", ts="TIMESTAMP", nonce="RANDOM", mac="HMAC_SIGNATURE"

### Root CA Configuration

Both the Keyfactor Command and AnyCA Gateway REST servers must trust the root CA, and if applicable, any subordinate CAs for all features to work as intended. Download the CA Certificate (and chain, if applicable) from HydrantId, and import them into the appropriate certificate store on the AnyCA Gateway REST server.

* **Windows** - If the AnyCA Gateway REST is running on a Windows host, the root CA and applicable subordinate CAs must be imported into the Windows certificate store. The certificates can be imported using the Microsoft Management Console (MMC) or PowerShell. 
* **Linux** - If the AnyCA Gateway REST is running on a Linux host, the root CA and applicable subordinate CAs must be present in the root CA certificate store. The location of this store varies per distribution, but is most commonly `/etc/ssl/certs/ca-certificates.crt`. The following is documentation on some popular distributions.
    * [Ubuntu - Managing CA certificates](https://ubuntu.com/server/docs/install-a-root-ca-certificate-in-the-trust-store)
    * [RHEL 9 - Using shared system certificates](https://docs.redhat.com/en/documentation/red_hat_enterprise_linux/9/html/securing_networks/using-shared-system-certificates_securing-networks#using-shared-system-certificates_securing-networks)
    * [Fedora - Using Shared System Certificates](https://docs.fedoraproject.org/en-US/quick-docs/using-shared-system-certificates/)

> The root CA and intermediate CAs must be trusted by both the Command server _and_ AnyCA Gateway REST server.

## Installation

1. Install the AnyCA Gateway REST per the [official Keyfactor documentation](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/InstallIntroduction.htm).

2. On the server hosting the AnyCA Gateway REST, download and unzip the latest [HydrantId AnyCA Gateway REST plugin](https://github.com/Keyfactor/hydrantid-cagateway/releases/latest) from GitHub.

3. Copy the unzipped directory (usually called `net6.0`) to the Extensions directory:

    ```shell
    Program Files\Keyfactor\AnyCA Gateway\AnyGatewayREST\net6.0\Extensions
    ```

    > The directory containing the HydrantId AnyCA Gateway REST plugin DLLs (`net6.0`) can be named anything, as long as it is unique within the `Extensions` directory.

4. Restart the AnyCA Gateway REST service.

5. Navigate to the AnyCA Gateway REST portal and verify that the Gateway recognizes the HydrantId plugin by hovering over the ⓘ symbol to the right of the Gateway on the top left of the portal.

## Configuration

1. Follow the [official AnyCA Gateway REST documentation](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCA-Gateway.htm) to define a new Certificate Authority, and use the notes below to configure the **Gateway Registration** and **CA Connection** tabs:

    * **Gateway Registration**

        The Gateway Registration tab configures the root or issuing CA certificate for the respective CA in HydrantId. The certificate selected here should be the issuing CA identified in the [Root CA Configuration](#root-ca-configuration) step.

    * **CA Connection**

        Populate using the configuration fields collected in the [requirements](#requirements) section.

        * **HydrantIdBaseUrl** - The Base URL For the HydrantId Endpoint similar to https://acm-stage.hydrantid.com.  Get this from HydrantId. 
        * **HydrantIdAuthId** - The AuthId Obtained from HydrantId. 
        * **HydrantIdAuthKey** - The AuthKey Obtained from HydrantId. 

2. Define [Certificate Profiles](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCP-Gateway.htm) and [Certificate Templates](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCA-Gateway.htm) for the Certificate Authority as required. One Certificate Profile must be defined per Certificate Template. It's recommended that each Certificate Profile be named after the Product ID.

    The GCP CAS AnyCA Gateway REST plugin downloads all Certificate Templates in the configured GCP Region/Project and interprets them as 'Product IDs' in the Gateway Portal.

    > For example, if the connected GCP project has the following Certificate Templates:
    > 
    > * `ServerAuth`
    > * `ClientAuth`
    >
    > The `Edit Templates` > `Product ID` dialog dropdown will show the following available 'ProductIDs':
    >
    > * `Default` -> Don't use a certificate template when enrolling certificates with this Template.
    > * `ServerAuth` -> Use the `ServerAuth` certificate template in GCP when enrolling certificates with this Template.
    > * `ClientAuth` -> Use the `ClientAuth` certificate template in GCP when enrolling certificates with this Template.

3. Follow the [official Keyfactor documentation](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCA-Keyfactor.htm) to add each defined Certificate Authority to Keyfactor Command and import the newly defined Certificate Templates.

4. In Keyfactor Command (v12.3+), for each imported Certificate Template, follow the [official documentation](https://software.keyfactor.com/Core-OnPrem/Current/Content/ReferenceGuide/Configuring%20Template%20Options.htm) to define enrollment fields for each of the following parameters:

    * **ValidityPeriod** - The desired lifetime time period could be Days, Months or Years. 
    * **ValidityUnits** - The desired lifetime time value some number indicating days, months or years. 
    * **RenewalDays** - The window that determines whether it is a renewal vs a re-issue. 



## License

Apache License 2.0, see [LICENSE](LICENSE).

## Related Integrations

See all [Keyfactor Any CA Gateways (REST)](https://github.com/orgs/Keyfactor/repositories?q=anycagateway).