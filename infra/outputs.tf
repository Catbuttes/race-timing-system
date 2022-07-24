output "rtsResources" {
  value = data.azurerm_resource_group.rtsResources.id
}

output "apiScopes" {
  value = azuread_application.api.oauth2_permission_scope_ids
}

output "apiIdentifierUri" {
  value = azuread_application.api.identifier_uris
}

output "apiTenantId" {
  value = var.ad_tenant_id
}

output "apiClientId" {
  value = azuread_application.api.application_id
}

output "frontendTenantId" {
  value = var.ad_tenant_id
}

output "frontendClientId" {
  value = azuread_application.frontend.application_id
}

output "frontendClientSecret" {
  value     = azuread_application_password.frontend_pass.value
  sensitive = true
}

resource "local_sensitive_file" "configs" {
  filename = "App Details.txt"
  content  = <<EOL
Tenant ID: ${var.ad_tenant_id}
API Client ID: ${azuread_application.api.application_id}
Frontend Client ID: ${azuread_application.frontend.application_id}
Frontend Client Secret: ${azuread_application_password.frontend_pass.value}
  EOL
}


