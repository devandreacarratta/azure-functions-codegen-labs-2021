using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsLabs.HTTPTrigger
{
    public class HTTPTriggerThrowingAnException
    {
        private readonly HelperService _helper = null;

        public HTTPTriggerThrowingAnException(HelperService helper)
        {
            _helper = helper;
        }

        [FunctionName("HTTPTriggerThrowingAnException")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            await Task.Delay(1);

            _helper.GenerateNewException("Ops, We have a problema!");
        }
    }
}