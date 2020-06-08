using System;

namespace My.NetCore.Framework.IOC.Exceptions
{
    public class RegisterDependencyException : SystemException
    {

        public RegisterDependencyException()
        {

        }

        public RegisterDependencyException(string message) : base(message) { }

    }
}
