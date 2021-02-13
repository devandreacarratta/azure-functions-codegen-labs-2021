using System;

namespace AzureFunctionsLabs
{
    public class HelperServiceTransient
    {
        public readonly Guid Id = Guid.Empty;
        public HelperServiceTransient()
        {
            Id = Guid.NewGuid();
        }
    }

}