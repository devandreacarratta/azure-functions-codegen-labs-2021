using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using AzureFunctionsLabs.DTO;

namespace AzureFunctionsLabs
{
    public class TimerTriggerDIFunction
    {
        // How to set cron (Italian link)
        // https://blog.devandreacarratta.it/azure-function-timertrigger-cron-value-utc/

        private readonly TimerTriggerDTO _dto;

        public TimerTriggerDIFunction(TimerTriggerDTO dto)
        {
            _dto = dto;
        }


        [FunctionName("TimerTriggerDIFunction")]
        public  void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
