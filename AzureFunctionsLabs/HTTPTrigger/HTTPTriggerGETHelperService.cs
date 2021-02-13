using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsLabs.HTTPTrigger
{
    public class HTTPTriggerGETHelperService
    {
        private readonly HelperServiceScoped _serviceScoped = null;
        private readonly HelperServiceTransient _serviceTransient = null;
        private readonly HelperService _service = null;

        public HTTPTriggerGETHelperService(HelperServiceScoped serviceScoped,
            HelperServiceTransient serviceTransient,
            HelperService service)
        {
            _serviceScoped = serviceScoped;
            _serviceTransient = serviceTransient;
            _service = service;
        }

        [FunctionName("HTTPTriggerGETHelperService")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var dto = new
            {
                HelperServiceScopedId = _serviceScoped.Id,
                HelperServiceTransientId = _serviceTransient.Id,
                HelperServiceId = _service.Id,
            };

            return new OkObjectResult(dto);
        }
    }
}