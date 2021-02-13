using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctionsLabs.HTTPTrigger
{
    public class HTTPTriggerThrowingAnException
    {
        public HTTPTriggerThrowingAnException()
        {
        }

        [FunctionName("HTTPTriggerThrowingAnException")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            await Task.Delay(1);

            throw new Exception("Ops, We have a problema!");
        }
    }
}