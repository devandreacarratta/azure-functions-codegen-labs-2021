using System;

namespace AzureFunctionsLabs
{
    public class HelperServiceScoped
    {
        public readonly Guid Id = Guid.Empty;
        public HelperServiceScoped()
        {
            Id = Guid.NewGuid();
        }
    }

}