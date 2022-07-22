data "azuread_client_config" "current" {}

data "azurerm_resource_group" "rtsResources" {
  name = "RTS-Resources"
}