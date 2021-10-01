using System;
using System.Runtime.Serialization;

namespace GroceryStoreAPI.ExceptionHandler
{
    [Serializable]
    public class BadRequestCustomException : Exception
    {
        public BadRequestCustomException()
        {
        }

        public BadRequestCustomException(string message) : base(message)
        {
        }

        public BadRequestCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRequestCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}