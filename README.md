# IET Web Service

[![Build Status](https://dev.azure.com/ucdavis/IETWS/_apis/build/status/ucdavis.ietws?branchName=master)](https://dev.azure.com/ucdavis/IETWS/_build/latest?definitionId=20&branchName=master)

## https://www.nuget.org/packages/ietws/

UCD IET WebService SDK for .Net Standard

UC Davis provides general web services, detailed at https://ucdavis.jira.com/wiki/spaces/IETP/pages/132808721/Web+Service+API.

This SDK attempts to provide a nice, standardized method for querying their web services.

# Example
```
var client = new IetClient(apiKey);
var result = await client.Contacts.Search(ContactSearchField.email, "email@ucdavis.edu");
```
