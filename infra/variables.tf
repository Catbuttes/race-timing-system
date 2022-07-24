variable "ad_tenant_id" {
  type        = string
  default     = "4abe5883-a4b4-4b25-b9b8-a2c45cb06fef"
  description = "The B2C tenant ID to deploy AD resources to"
}

variable "azure_tenant_id" {
  type        = string
  default     = "e75239ad-66be-4f6a-a15f-9c84525685bc"
  description = "The tenant ID to deploy Azure resources to"
}