using System;
using System.Collections.Generic;
using System.Text;

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
