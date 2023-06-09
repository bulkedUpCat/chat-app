param location string
param storageSkuName string = 'Standard_LRS'
param storageAccountName string

targetScope = 'resourceGroup'

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: storageSkuName
  }
}

var key = storageAccount.listKeys().keys[0].value

output storageAccessKey string = key
output storageConnectionString string = 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};AccountKey=${key}'
output storageEndpoint object = storageAccount.properties.primaryEndpoints
