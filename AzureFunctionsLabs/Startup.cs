using AzureFunctionsLabs;
using AzureFunctionsLabs.DTO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunctionsLabs
{
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// abstract class from FunctionsStartup
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Read local.setting.json
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<QueueConfigurationDTO>
                (
                    s => new QueueConfigurationDTO()
                    {
                        ConnectionString = config["queueconnectionstring"],
                        QueueName = config["queuename"],
                        SecondToWaitBeforeTrigger = Convert.ToInt32(config["SecondToWaitBeforeTrigger"]),
                    }
                ) ;

            builder.Services.AddSingleton<BlobConfigurationDTO>
                (
                    s => new BlobConfigurationDTO()
                    {
                        ComputeLinesNumber = Convert.ToBoolean(config["ComputeLinesNumber"]),
                        ShowLenght = Convert.ToBoolean(config["ShowLenght"]),
                    }
                );

            builder.Services.AddSingleton<HTTPTriggerDTO>
                (
                    s => new HTTPTriggerDTO()
                    {
                        LogDateTimeUTC = Convert.ToBoolean(config["LogDateTimeUTC"]),
                    }
                );
        }
    }
}