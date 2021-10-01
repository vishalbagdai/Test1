using System;
using System.Runtime.Serialization;

namespace GroceryStoreAPI.ExceptionHandler
{
    [Serializable]
    public class ForbiddenCustomException : Exception
    {
        public ForbiddenCustomException()
        {
        }

        public ForbiddenCustomException(string message) : base(message)
        {
        }

        public ForbiddenCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ForbiddenCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}