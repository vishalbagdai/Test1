using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStoreApi.Model
{
    public class ErrorResponse
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        /* we can add as many property here we want e.g. errorCode, source, apiName etc..*/
    }
}
