v1.1.4
- Added flow logging (step diagram at Trace level) for Enroll, Synchronize and Revoke
- Validity is now validated: ValidityPeriod must be Days, Months or Years and ValidityUnits a positive whole number
- Added the RenewalWindowDays CAConnection setting (default 30). A request with a prior certificate is reissued when more than RenewalWindowDays remain, renewed inside the window, and enrolled as new once expired, supporting shorter-lived (e.g. 200 day) certificates
- Validity is now validated: ValidityPeriod must be Days, Months or Years and ValidityUnits a positive whole number, so shorter-lived (e.g. 200 day) certificates can be requested 

v1.1.3
- Fixed sync Issue related to API connectivity to Hydrant ID
  
v1.1.2
- Recompiled agains the latest gateway and Bouncy Castle Frameworks
  
v1.1.1
- Fixed error handing to match Hydrant new API Structure

v1.1.0
- Added Support for Meta Data In Keyfactor
- Put enroll on a timer to wait for request so Meta Data Could be Pulled down

v1.0.3:
- Original Release Version
