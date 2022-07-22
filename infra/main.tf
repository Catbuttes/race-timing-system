terraform {
  required_providers {
    random = {
      source  = "hashicorp/random"
      version = "3.3.2"
    }

    local = {
      source  = "hashicorp/local"
      version = "2.2.3"
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
  tenant_id = var.tenant_id
}

provider "azurerm" {
  tenant_id = var.tenant_id
  features {}
}

resource "random_uuid" "api_randomizer" {
}

resource "random_uuid" "frontend_randomizer" {
}


resource "azuread_application" "api" {
  display_name     = "RTS Backend API"
  identifier_uris  = ["api://dev.buttes.rts.api/${random_uuid.api_randomizer.result}"]
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
      value                      = "API.Access"
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

}

resource "azuread_service_principal" "api_sp" {
  application_id               = azuread_application.api.application_id
  app_role_assignment_required = false
  owners                       = [data.azuread_client_config.current.object_id]
}

resource "azuread_application" "frontend" {
  display_name     = "RTS Frontend"
  identifier_uris  = ["api://dev.buttes.rts.frontend/${random_uuid.frontend_randomizer.result}"]
  owners           = [data.azuread_client_config.current.object_id]
  sign_in_audience = "AzureADandPersonalMicrosoftAccount"

  web {
    homepage_url  = "https://rts.buttes.dev"
    redirect_uris = ["https://rts.buttes.dev/signin-oidc"]

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