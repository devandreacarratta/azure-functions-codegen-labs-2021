using AzureFunctionsLabs.DTO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureFunctionsLabs
{
    public class BlobTriggerDIFunction
    {
        private readonly BlobConfigurationDTO _configuration;

        public BlobTriggerDIFunction(BlobConfigurationDTO configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("BlobTriggerDIFunction")]
        public async Task Run(
            [BlobTrigger("csv-input/{name}", Connection = "blobconnectionstring")] Stream input,
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n");

            if (_configuration.ComputeLinesNumber)
            {
                using (var reader = new StreamReader(input))
                {
                    var text = await reader.ReadToEndAsync();

                    var lines = text.Split(
                        Environment.NewLine.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);

                    log.LogInformation($"File has {lines.Length} lines");
                }
            }

            if (_configuration.ShowLenght)
            {
                log.LogInformation($"Size: {input.Length} Bytes");
            }
        }
    }
}