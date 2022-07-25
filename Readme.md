# Race Timing System

This is an entry for the [CSEE Soc](https://www.essexstudent.com/organisation/6490/) Summer Challenge. The original challenge is in [./doc/requirements.md](./doc/requirements.md) I _may_ have gone a little overboard with it, using Azure AD B2C as an IDP and a multi layered design... I'm going to document the entire setup though...

The frontend can be found at [https://rts-frontend-buttes.azurewebsites.net/](https://rts-frontend-buttes.azurewebsites.net/) while the backend will be at [https://rts-api-buttes.azurewebsites.net/](https://rts-api-buttes.azurewebsites.net/), with the OpenAPI/Swagger frontend at [https://rts-api-buttes.azurewebsites.net/swagger](https://rts-api-buttes.azurewebsites.net/swagger). It is presently hosted on Azure using mostly free tier resources (CosmosDB is on the serverless plan and is expected to cost under $1).

Details of the azure setup are mostly contained within the terraform files in the infra directory. The only thing missing is the configuration of the Azure AD B2C instance and the setup of the initial subscription and resource group.