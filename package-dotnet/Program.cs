using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

class Program
{
    static async Task Main(string[] args)
    {
        string subscriptionId = ""; //add subscription ID, or add ENV variable
        string resourceGroupName = "my-sdk-ishak";
        string location = "eastus";
        string storageAccountName = "ishakystorageacc400" + Guid.NewGuid().ToString("n").Substring(0, 8);
        //AzureLocation location2 = AzureLocation.WestUS2;

        var credential = new DefaultAzureCredential();
        var armClient = new ArmClient(credential, subscriptionId);

        // Create Resource Group
        var subscription = await armClient.GetDefaultSubscriptionAsync();
        var rgData = new ResourceGroupData(location);
        var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, rgData);
        var resourceGroup = rgLro.Value;
        Console.WriteLine("resource group created successfuly");
    }
    
}
