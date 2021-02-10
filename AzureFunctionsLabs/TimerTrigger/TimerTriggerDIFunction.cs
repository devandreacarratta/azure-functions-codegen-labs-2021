using AzureFunctionsLabs.DTO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunctionsLabs
{
    public class TimerTriggerDIFunction
    {
        private readonly TimerTriggerDTO _dto;

        public TimerTriggerDIFunction(TimerTriggerDTO dto)
        {
            _dto = dto;
        }

        // How to disable an EndPoint (Italian link)
        // https://blog.devandreacarratta.it/azure-function-endpoint-disable-attribute/
        [Disable]
        [FunctionName("TimerTriggerDIFunction")]
        // How to set cron (Italian link)
        // https://blog.devandreacarratta.it/azure-function-timertrigger-cron-value-utc/
        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}