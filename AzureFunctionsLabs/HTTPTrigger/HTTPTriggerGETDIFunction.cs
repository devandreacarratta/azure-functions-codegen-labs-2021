using AzureFunctionsLabs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AzureFunctionsLabs
{
    public class HTTPTriggerGETDIFunction
    {
        private readonly HTTPTriggerDTO _configuration;

        public HTTPTriggerGETDIFunction(HTTPTriggerDTO configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("HTTPTriggerGETDIFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HTTPTriggerGETDIFunction works");
            await Task.Delay(1000); // do something ....

            if (_configuration.LogDateTimeUTC)
            {
                log.LogInformation($"TIme ... {DateTime.UtcNow}");
            }
            log.LogInformation("HTTPTriggerGETDIFunction END");

            var result = new
            {
                FreeText = "Hello World from HTTPTriggerGETDIFunction",
                DateAndTime = DateTime.UtcNow,
                LogDateTimeUTC = _configuration.LogDateTimeUTC
            };

            return new OkObjectResult(result);
        }
    }
}