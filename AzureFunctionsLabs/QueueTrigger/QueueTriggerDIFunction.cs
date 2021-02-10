using AzureFunctionsLabs.DTO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsLabs
{
    public class QueueTriggerDIFunction
    {
        private readonly QueueTriggerDTO _dto;

        public QueueTriggerDIFunction(QueueTriggerDTO dto)
        {
            _dto = dto;
        }

        [FunctionName("QueueTriggerDIFunction")]
        public static void Run([QueueTrigger("messages", Connection = "queueconnectionstring")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}