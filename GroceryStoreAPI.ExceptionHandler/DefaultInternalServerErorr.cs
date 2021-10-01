using System;
using System.Runtime.Serialization;

namespace GroceryStoreAPI.ExceptionHandler
{
    [Serializable]
    public class DefaultInternalServerErorr : Exception
    {
        public DefaultInternalServerErorr()
        {
        }

        public DefaultInternalServerErorr(string message) : base(message)
        {
        }

        public DefaultInternalServerErorr(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DefaultInternalServerErorr(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}