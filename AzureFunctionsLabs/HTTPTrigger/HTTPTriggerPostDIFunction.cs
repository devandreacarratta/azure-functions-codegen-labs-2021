using AzureFunctionsLabs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureFunctionsLabs
{
    public class HTTPTriggerPostDIFunction
    {
        private readonly QueueConfigurationDTO _configuration;

        private static readonly TimeSpan _timeToLiveQueueMessage = new TimeSpan(24 * 7, 0, 0);

        public HTTPTriggerPostDIFunction(QueueConfigurationDTO configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("HTTPTriggerPostDIFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            // { "FreeText" :"Hello World from PostMan API"}

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            DateTime runAt = DateTime.UtcNow.AddSeconds(_configuration.SecondToWaitBeforeTrigger);

            // Add Message to Queue --> use in QueueTriggerDIFunction
            CloudQueueMessage message = new CloudQueueMessage(requestBody);

            QueueRequestOptions options = null;
            OperationContext operationContext = null;

            TimeSpan tsRunAt = new TimeSpan(runAt.Ticks);
            TimeSpan tsNow = new TimeSpan(DateTime.UtcNow.Ticks);

            CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(_configuration.ConnectionString);

            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference(_configuration.QueueName);

            await queue.CreateIfNotExistsAsync();

            await queue.AddMessageAsync(message,
                _timeToLiveQueueMessage,
                tsRunAt.Subtract(tsNow),
                options,
                operationContext
                );

            return new OkObjectResult(message.Id);
        }
    }
}