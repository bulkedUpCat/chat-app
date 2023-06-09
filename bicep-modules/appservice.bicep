param location string = resourceGroup().location
param apiAppServiceName string
param blazorAppServiceName string
param appServicePlanId string
param keyVaultName string
param functionName string

resource apiAppService 'Microsoft.Web/sites@2021-01-15' = {
  name: apiAppServiceName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServicePlanId
    siteConfig: {
      appSettings: [
        {
          name: 'AzureKeyVaultUrl'
          value: 'https://${keyVaultName}${environment().suffixes.keyvaultDns}'
        }
      ]
    }
  }
}

resource blazorAppService 'Microsoft.Web/sites@2021-01-15' = {
  name: blazorAppServiceName
  location: location
  properties: {
    serverFarmId: appServicePlanId
    siteConfig: {
      appSettings: [
        {
          name: 'APIUrl'
          value: 'http://${apiAppServiceName}.azurewebsites.net/api/'
        }
        {
          name: 'AzureFunctionsUrl'
          value: 'https://${functionName}.azurewebsites.net/api/wordDocuments'
        }
      ]
    }
  }
}

output apiAppServicePrincipalId string = apiAppService.identity.principalId
