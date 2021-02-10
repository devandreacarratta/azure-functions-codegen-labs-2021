using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsLabs.DTO
{
    public class QueueConfigurationDTO
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}
