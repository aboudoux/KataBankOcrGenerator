using System;
using System.Runtime.Serialization;

namespace KataBankOcrGenerator.Exceptions
{
    [Serializable]
    public class AccountNumberException : Exception
    {
        public AccountNumberException()
        {
        }

        public AccountNumberException(string message) : base(message)
        {
        }

        public AccountNumberException(string message, Exception inner) : base(message, inner)
        {
        }

        protected AccountNumberException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}