using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsLabs
{

    public static class BlobTriggerFunction
    {
        [FunctionName("BlobTriggerFunction")]
        public static void Run([BlobTrigger("csv-input-fake/{name}", Connection = "blobconnectionstring")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
