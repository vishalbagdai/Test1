using System;
using System.Runtime.Serialization;

namespace GroceryStoreAPI.ExceptionHandler
{
    [Serializable]
    public class UnauthorizedCustomException : Exception
    {
        public UnauthorizedCustomException()
        {
        }

        public UnauthorizedCustomException(string message) : base(message)
        {
        }

        public UnauthorizedCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}