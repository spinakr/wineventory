az login

az account set -s <subId>

az group create --name wineventory --location northeurope

<!-- Create storage account -->
az storage account create --name winestorage --location northeurope --resource-group wineventory --sku Standard_GRS

az storage container create --name webapp --account-name winer --public-access blob

<!-- Deploy app files to blob container -->
for f in $(find ./build); do az storage blob upload -c webapp --account-name winer -f $f -n ${f#*/build/}; done

<!-- Create function app -->
az functionapp create --deployment-source-url https://github.com/Azure-Samples/functions-quickstart  \
--resource-group wineventory --consumption-plan-location northeurope \
--name winefunctions --storage-account winestorage  