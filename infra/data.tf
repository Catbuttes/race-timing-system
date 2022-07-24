data "azuread_client_config" "current" {}

data "azurerm_resource_group" "rtsResources" {
  name = "RTS-Resources"
}

data "archive_file" "frontend" {
  type        = "zip"
  source_dir  = "../frontend/bin/Release/net6.0/linux-x64/publish"
  output_path = "../artifacts/frontend-${uuid()}.zip"
}

data "archive_file" "backend" {
  type        = "zip"
  source_dir  = "../backend/bin/Release/net6.0/linux-x64/publish"
  output_path = "../artifacts/backend-${uuid()}.zip"
}