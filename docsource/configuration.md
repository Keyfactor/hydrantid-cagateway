## Overview

HydrantId operates a PKI as a service platform for customers around the globe. The AnyGateway solution for HydrantId is designed to allow Keyfactor Command:

* CA Sync:
    * Download all certificates issued by connected Enterprise tier CAs in HydrantId (full sync).
* Certificate enrollment for all published HydrantId Certificate SKUs:
    * Support certificate enrollment (new keys/certificate).
* Certificate revocation:
    * Request revocation of a previously issued certificate.


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

## Gateway Registration

The Gateway Registration tab configures the root or issuing CA certificate for the respective CA in GCP CAS. The certificate selected here should be the issuing CA identified in the [Root CA Configuration](#root-ca-configuration) step.


## Certificate Template Creation Step

Define [Certificate Profiles](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCP-Gateway.htm) and [Certificate Templates](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCA-Gateway.htm) for the Certificate Authority as required. One Certificate Profile must be defined per Certificate Template. It's recommended that each Certificate Profile be named after the Product ID.

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

## Mechanics

### Enrollment/Renewal/Reissuance

The GCP CAS AnyCA Gateway REST plugin treats _all_ certificate enrollment as a new enrollment.

### Synchronization

The GCP CAS AnyCA Gateway REST plugin uses the [`ListCertificatesRequest` RPC](https://cloud.google.com/certificate-authority-service/docs/reference/rpc/google.cloud.security.privateca.v1#google.cloud.security.privateca.v1.ListCertificatesRequest) when synchronizing certificates from GCP. At the time the latest release, this RPC does not enable granularity to list certificates issued by a particular CA. As such, the CA Synchronization job implemented by the plugin will _always_ download all certificates issued by _any CA_ in the CA Pool.

> Friendly reminder to always follow the [GCP CAS best practices](https://cloud.google.com/certificate-authority-service/docs/best-practices)
