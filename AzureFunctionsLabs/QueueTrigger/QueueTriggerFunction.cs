using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsLabs
{
    public static class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("messages", Connection = "queueconnectionstring")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}