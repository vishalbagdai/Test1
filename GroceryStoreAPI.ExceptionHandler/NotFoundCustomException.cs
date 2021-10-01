using System;
using System.Runtime.Serialization;

namespace GroceryStoreAPI.ExceptionHandler
{
    [Serializable]
    public class NotFoundCustomException : Exception
    {
        public NotFoundCustomException()
        {
        }

        public NotFoundCustomException(string message) : base(message)
        {
        }

        public NotFoundCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}