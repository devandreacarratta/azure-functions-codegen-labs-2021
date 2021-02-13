using System;

namespace AzureFunctionsLabs
{
    public class HelperService
    {
        public void GenerateNewException(string message)
        {
            throw new Exception(message);
        }
    }
}