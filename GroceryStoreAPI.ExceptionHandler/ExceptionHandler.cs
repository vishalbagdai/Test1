using System;
using System.Net;

namespace GroceryStoreAPI.ExceptionHandler
{
    public static class ExceptionHandler
    {
        public static void ThrowException(HttpStatusCode httpStatusCode, string message)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new NotFoundCustomException();
                case HttpStatusCode.BadRequest:
                    throw new BadRequestCustomException();
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedCustomException();
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenCustomException();
                default:
                    throw new DefaultInternalServerErorr();
            }
        }
    }
}
