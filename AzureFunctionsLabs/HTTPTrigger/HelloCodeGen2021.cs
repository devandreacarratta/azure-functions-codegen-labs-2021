using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsLabs.HTTPTrigger
{
    public class HelloCodeGen2021
    {
        public HelloCodeGen2021()
        {
        }

        [FunctionName("HelloCodeGen2021")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string responseMessage = "Hello CodeGen 2021!";

            await Task.Delay(1000); // Wait more followers ....

            return new OkObjectResult(responseMessage);
        }
    }
}