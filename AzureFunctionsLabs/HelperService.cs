using System;

namespace AzureFunctionsLabs
{
    public class HelperService
    {
        public readonly Guid Id = Guid.Empty;
        public HelperService()
        {
            Id = Guid.NewGuid();
        }
        public void GenerateNewException(string message)
        {
            throw new Exception(message);
        }
    }

}