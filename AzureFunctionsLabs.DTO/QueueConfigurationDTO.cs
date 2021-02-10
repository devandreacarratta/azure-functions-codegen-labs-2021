namespace AzureFunctionsLabs.DTO
{
    public class QueueConfigurationDTO
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }

        public int SecondToWaitBeforeTrigger { get; set; }
    }
}