## Overview

HydrantId operates a PKI-as-a-service platform for customers around the globe. The AnyGateway solution for HydrantId allows Keyfactor Command to perform:

- **CA Sync**:
  - Download all certificates issued by connected Enterprise-tier CAs in HydrantId (full sync).
- **Certificate Enrollment**:
  - Support certificate enrollment (new keys/certificate).
  - Intelligent handling of Renewal vs Reissue based on certificate expiration.
- **Certificate Revocation**:
  - Request revocation of previously issued certificates with mapped revocation reasons.

---

## Requirements

### 🔐 HydrantID API Key Setup Guide

This guide explains how to generate and use an API Key ID and Secret in HydrantID for authenticated API access.

#### 📍 Where to Find API Key Management

1. **Log in** to your HydrantID instance.
   - Example: https://acm-stage.hydrantid.com
2. Click your **user profile icon** (top right) and select **"Profile"**.
3. In the **Profile** page, scroll to the section labeled `API Keys`.

#### ➕ Add a New API Key

1. Click **"ADD API KEY"** (top right of the API Keys section).
2. A new API Key will be generated with:
   - A unique **API ID**
   - A **Secret API Key** — copy it immediately as it is only shown once.

#### 🧾 Notes on API Keys

- **ID** = what you'll pass in the HAWK `id` field
- **Key** = secret used to generate HAWK signature
- Each key shows `Created` and `Last Used` timestamps for traceability

#### 🔐 Using the API ID and Key with HAWK

HydrantID uses [HAWK Authentication](https://github.com/hueniverse/hawk) to secure its API.

##### Required Fields in Authorization Header:
```text
Hawk id="API_ID", ts="TIMESTAMP", nonce="RANDOM", mac="HMAC_SIGNATURE"
```

Each HTTP request dynamically constructs a HAWK header using:
- API ID
- Secret API Key
- Current timestamp
- Cryptographically random nonce
- SHA-256 algorithm

### Root CA Configuration

Both the Keyfactor Command and AnyCA Gateway REST servers must trust the root CA, and any applicable intermediate CAs for HydrantID.

Refer to:
- [Ubuntu - Managing CA certificates](https://ubuntu.com/server/docs/install-a-root-ca-certificate-in-the-trust-store)
- [RHEL 9 - Using shared system certificates](https://docs.redhat.com/en/documentation/red_hat_enterprise_linux/9/html/securing_networks/using-shared-system-certificates_securing-networks#using-shared-system-certificates_securing-networks)
- [Fedora - Using Shared System Certificates](https://docs.fedoraproject.org/en-US/quick-docs/using-shared-system-certificates/)

---

## Gateway Registration

The Gateway Registration tab configures the root or issuing CA certificate for the respective CA in HydrantId.  
The certificate selected here should match the issuing CA identified in the [Root CA Configuration](#root-ca-configuration) step.

---

## Certificate Template Creation Step

Define [Certificate Profiles](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCP-Gateway.htm) and [Certificate Templates](https://software.keyfactor.com/Guides/AnyCAGatewayREST/Content/AnyCAGatewayREST/AddCA-Gateway.htm) for the Certificate Authority as required.

Naming Recommendations:
- Each Certificate Profile should be named after its Product ID.

Behavior:
- The plugin maps HydrantID Policy Names directly to Product IDs in the Gateway Portal.

Example:
| GCP CAS Template | Product ID |
|:------------------|:-----------|
| `ServerAuth` | ServerAuth |
| `ClientAuth` | ClientAuth |

Selecting "Default" bypasses specifying a template.

---

# Mechanics

## Enrollment/Renewal/Reissuance

All certificate enrollment operations are submitted as "new" requests. However, the plugin supports intelligent handling:

- **New Enrollment**:
  - Submits a new CSR against the selected HydrantId Policy.
- **Renewal vs Reissue**:
  - Uses the prior certificate's serial number (`PriorCertSN`) to retrieve the existing certificate.
  - Compares the expiration date against the current time.
    - If expiration is **within** `RenewalDays` (default 30 days): Submit a **Renewal** request.
    - If expiration is **outside** `RenewalDays`: Submit a **Reissue** request (new CSR, same policy).

Template parameters:
| Parameter | Purpose |
|:---|:---|
| `RenewalDays` | Number of days before expiration considered a renewal window |
| `ValidityPeriod` | Period length (Days/Months/Years) |
| `ValidityUnits` | Value for the chosen period type |

## Certificate Synchronization

The plugin uses the `/api/v2/certificates` endpoint to perform full synchronization:

- **Paging**:
  - Fetches certificates in batches of 100 (default page size).
- **Filtering**:
  - Only certificates with statuses `Generated` or `Revoked` are processed.
- **Retry Logic**:
  - Up to **5 retry attempts** are made on API failures during synchronization before failing the job.
- **Certificate Parsing**:
  - PEM chains are split into individual certificates.

> Note: HydrantId's API does not allow filtering certificates by CA, so all certificates from the tenant are synced.

## Certificate Revocation

Revocation requests are sent via a PATCH to the `/api/v2/certificates/{id}` endpoint.

**Mapped Revocation Reasons**:

| Keyfactor Reason (RFC 5280) | HydrantID Reason |
|:---|:---|
| 0 (Unspecified) | Unspecified |
| 1 (KeyCompromise) | KeyCompromise |
| 2 (CACompromise) | CACompromise |
| 3 (AffiliationChanged) | AffiliationChanged |
| 4 (Superseded) | Superseded |
| 5 (CessationOfOperation) | CessationOfOperation |
| 6 (CertificateHold) | CertificateHold |
| 8 (RemoveFromCRL) | RemoveFromCRL |
| 9 (PrivilegeWithdrawn) | PrivilegeWithdrawn |
| 10 (AACompromise) | AACompromise |

## Connection Information Validation

The following fields are required when connecting the Gateway to HydrantId:

- `HydrantIdBaseUrl`
- `HydrantIdAuthId`
- `HydrantIdAuthKey`

Missing or empty fields will cause the plugin initialization to fail.

---

# Additional Notes

- After enrollment, the plugin polls HydrantId's `/csr/{id}/certificate` endpoint for up to **30 seconds** to retrieve the newly issued certificate.
- If the certificate is still unavailable, the enrollment will be marked **Pending** in Command and should be retried.
- The plugin uses the Keyfactor standard logging infrastructure (`Keyfactor.Logging`).

# 📌 Related Documentation

- [HAWK Authentication Specification](https://github.com/hueniverse/hawk)
- [HydrantID API Documentation](https://support.hydrantid.com/hc/en-us)
