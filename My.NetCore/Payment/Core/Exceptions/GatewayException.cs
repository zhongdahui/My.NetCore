using System;

namespace My.NetCore.Payment.Core.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(string message): base(message)
        {
        }
    }
}
