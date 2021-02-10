using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace AzureFunctionsLabs
{
    public static class BlobTriggerFunction
    {
        // How to disable an EndPoint (Italian link)
        // https://blog.devandreacarratta.it/azure-function-endpoint-disable-attribute/
        [Disable]
        [FunctionName("BlobTriggerFunction")]
        public static void Run([BlobTrigger("csv-input-fake/{name}", Connection = "blobconnectionstring")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}