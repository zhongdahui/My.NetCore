using System;

namespace My.NetCore.Framework.IOC.Exceptions
{
    public class UnableResolveDependencyException : SystemException
    {

        public UnableResolveDependencyException()
        {

        }

        public UnableResolveDependencyException(string message) : base(message) { }

    }
}
