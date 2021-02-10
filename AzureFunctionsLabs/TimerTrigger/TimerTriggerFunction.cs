using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsLabs
{
    public static class TimerTriggerFunction
    {
        // How to set cron (Italian link)
        // https://blog.devandreacarratta.it/azure-function-timertrigger-cron-value-utc/

        [FunctionName("TimerTriggerFunction")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
