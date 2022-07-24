terraform {
  required_providers {
    local = {
      source  = "hashicorp/local"
      version = "2.2.3"
    }

    archive = {
      source  = "hashicorp/archive"
      version = "2.2.0"
    }

    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.14.0"
    }

    azuread = {
      source  = "hashicorp/azuread"
      version = "2.26.1"
    }
  }
}

provider "azuread" {
  # The RTS User Database Azure AD B2C Tenant I have set up manually
  tenant_id = var.ad_tenant_id
}

provider "azurerm" {
  tenant_id = var.azure_tenant_id
  features {}
}

resource "azuread_application" "api" {
  display_name     = "RTS Backend API"
  identifier_uris  = ["https://rtsusers.onmicrosoft.com/rtsapi"]
  owners           = [data.azuread_client_config.current.object_id]
  sign_in_audience = "AzureADandPersonalMicrosoftAccount"

  api {
    requested_access_token_version = "2"

    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "API Access"
      enabled                    = true
      id                         = "eb00a5b7-e117-43c2-b96f-5b6775cb4d1b"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "API Access"
      value                      = "Api.Access"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Lap Write Only"
      enabled                    = true
      id                         = "e4a90a2f-1420-48fd-bdb5-5e86c116688c"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Lap Write Only"
      value                      = "Laps.WriteOnly"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Lap Manage"
      enabled                    = true
      id                         = "433d7d64-c86c-411a-8f47-8538fb3da249"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Lap Manage"
      value                      = "Laps.Manage"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Race Manage"
      enabled                    = true
      id                         = "07886cde-260e-46e0-b4cd-7bf9f4471ddc"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Race Manage"
      value                      = "Races.Manage"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Driver Manage"
      enabled                    = true
      id                         = "bbe81932-d6fa-4f2e-85a0-fdd292e18772"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Driver Manage"
      value                      = "Drivers.Manage"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Tag Manage"
      enabled                    = true
      id                         = "4a5fe573-38fa-49f1-9221-2bcab1cf3af9"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Tag Manage"
      value                      = "Tags.Manage"
    }
    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "Attribute Manage"
      enabled                    = true
      id                         = "5a3e0184-1306-4739-8c1a-d9e7ab011488"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "Attribute Manage"
      value                      = "Attributes.Manage"
    }

  }

   # Microsoft Graph Permissions
  required_resource_access {
    resource_app_id = "00000003-0000-0000-c000-000000000000"

    resource_access {
      id   = "37f7f235-527c-4136-accd-4a02d197296e"
      type = "Scope"
    }

    resource_access {
      id   = "7427e0e9-2fba-42fe-b0c0-848c9e6a8182"
      type = "Scope"
    }
  }

}

resource "azuread_service_principal" "api_sp" {
  application_id               = azuread_application.api.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

resource "azuread_application" "frontend" {
  display_name     = "RTS Frontend"
  identifier_uris  = ["https://rtsusers.onmicrosoft.com/rtsfrontend"]
  owners           = [data.azuread_client_config.current.object_id]
  sign_in_audience = "AzureADandPersonalMicrosoftAccount"

  web {
    homepage_url  = "https://rts.buttes.dev"
    redirect_uris = ["https://rts.buttes.dev/signin-oidc", "https://rts-frontend-buttes.azurewebsites.net/signin-oidc"]

    implicit_grant {
      access_token_issuance_enabled = true
      id_token_issuance_enabled     = true
    }
  }

  api {
    requested_access_token_version = "2"

    oauth2_permission_scope {
      admin_consent_description  = "Allow application access to the API"
      admin_consent_display_name = "API Access"
      enabled                    = true
      id                         = "671a4545-ab82-44f9-a10f-125cbe91f16b"
      type                       = "Admin"
      user_consent_description   = "Allow application access to the API"
      user_consent_display_name  = "API Access"
      value                      = "API.Access"
    }
  }

  required_resource_access {
    resource_app_id = azuread_application.api.application_id

    resource_access {
      id   = "eb00a5b7-e117-43c2-b96f-5b6775cb4d1b"
      type = "Scope"
    }
    resource_access {
      id   = "433d7d64-c86c-411a-8f47-8538fb3da249"
      type = "Scope"
    }
    resource_access {
      id   = "07886cde-260e-46e0-b4cd-7bf9f4471ddc"
      type = "Scope"
    }
    resource_access {
      id   = "bbe81932-d6fa-4f2e-85a0-fdd292e18772"
      type = "Scope"
    }
    resource_access {
      id   = "4a5fe573-38fa-49f1-9221-2bcab1cf3af9"
      type = "Scope"
    }
    resource_access {
      id   = "5a3e0184-1306-4739-8c1a-d9e7ab011488"
      type = "Scope"
    }
  }

  # Microsoft Graph Permissions
  required_resource_access {
    resource_app_id = "00000003-0000-0000-c000-000000000000"

    resource_access {
      id   = "37f7f235-527c-4136-accd-4a02d197296e"
      type = "Scope"
    }

    resource_access {
      id   = "7427e0e9-2fba-42fe-b0c0-848c9e6a8182"
      type = "Scope"
    }
  }

}

resource "azuread_service_principal" "frontend_sp" {
  application_id               = azuread_application.frontend.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

resource "azuread_application_password" "frontend_pass" {
  application_object_id = azuread_application.frontend.object_id
  end_date_relative     = "1440h"
}

resource "azurerm_cosmosdb_account" "rtsDb" {
  name                = "rts-database"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  location            = "eastus"
  offer_type          = "Standard"

  capabilities {
    name = "EnableServerless"
  }

  consistency_policy {
    consistency_level = "ConsistentPrefix"
  }

    geo_location {
      location = "eastus"
      failover_priority = 0
    }
}

resource "azurerm_cosmosdb_sql_database" "rtsDb_database" {
  name = "rts-data"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  account_name = azurerm_cosmosdb_account.rtsDb.name
}

resource "azurerm_cosmosdb_sql_container" "rtsDb_container" {
  name = "RTSContext"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  account_name = azurerm_cosmosdb_account.rtsDb.name
  database_name = azurerm_cosmosdb_sql_database.rtsDb_database.name
  partition_key_path    = "/definition/id"
}

resource "azurerm_service_plan" "rts_service_plan" {
  name                = "RTS-Service-Plan"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  location            = data.azurerm_resource_group.rtsResources.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "api_app" {
  name                = "rts-api-buttes"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  location            = azurerm_service_plan.rts_service_plan.location
  service_plan_id     = azurerm_service_plan.rts_service_plan.id
  zip_deploy_file     = data.archive_file.backend.output_path

  site_config {
    always_on         = false
    health_check_path = "/healthz"
    application_stack {
      dotnet_version = "6.0"
    }
  }

  app_settings = tomap({
    "ASPNETCORE_ENVIRONMENT" = "Production"
    "AzureAdB2C__ClientId" = "${azuread_application.api.application_id}"
    "AzureAdB2C__TenantId" = "${var.ad_tenant_id}"

    "ConnectionStrings__RtsDb" = "AccountEndpoint=${azurerm_cosmosdb_account.rtsDb.endpoint};AccountKey=${azurerm_cosmosdb_account.rtsDb.primary_key};"
  })


}

resource "azurerm_linux_web_app" "frontend_app" {
  name                = "rts-frontend-buttes"
  resource_group_name = data.azurerm_resource_group.rtsResources.name
  location            = azurerm_service_plan.rts_service_plan.location
  service_plan_id     = azurerm_service_plan.rts_service_plan.id
  zip_deploy_file     = data.archive_file.frontend.output_path

  site_config {
    always_on         = false
    health_check_path = "/healthz"
    application_stack {
      dotnet_version = "6.0"
    }
  }

  app_settings = tomap({
    "AzureAdB2C__ClientId" = "${azuread_application.frontend.application_id}"
    "AzureAdB2C__TenantId" = "${var.ad_tenant_id}"
    "AzureAdB2C__ClientSecret" = "${azuread_application_password.frontend_pass.value}"

    "BackendConfig__BaseUrl"   = "https://${azurerm_linux_web_app.api_app.default_hostname}"
    "BackendConfig__Scopes"   = "https://rtsusers.onmicrosoft.com/rtsapi/Api.Access https://rtsusers.onmicrosoft.com/rtsapi/Driver.Manage"
    "ASPNETCORE_ENVIRONMENT"   = "Production"
  })
}