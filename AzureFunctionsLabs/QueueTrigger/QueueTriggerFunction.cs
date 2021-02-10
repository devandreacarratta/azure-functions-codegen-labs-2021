using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsLabs
{
    public static class QueueTriggerFunction
    {
        // How to disable an EndPoint (Italian link)
        // https://blog.devandreacarratta.it/azure-function-endpoint-disable-attribute/
        [Disable]
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("messages-fake", Connection = "queueconnectionstring")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}