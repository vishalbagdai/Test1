using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.AspNetCore.Builder;
using System;
using System.Net.Mime;
using GroceryStoreAPI.ExceptionHandler;
using GroceryStoreApi.Model;
using Newtonsoft.Json;

namespace GroceryStoreAPI
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            string errorText = string.Empty;
            //  httpContext.Response.ContentType = ContentType.Type;
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundCustomException notFoundCustomException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorText = notFoundCustomException.Message;
                    break;
                case BadRequestCustomException badRequestCustomException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorText = badRequestCustomException.Message;
                    break;
                //i havent implemeted authorization portion but this is how we can catch in custom way
                case ForbiddenCustomException forbiddenCustomException: 
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorText = forbiddenCustomException.Message;
                    break;
                //i havent implemeted authentication portion but this is how we can catch in custom way
                case UnauthorizedCustomException unauthorizedCustomException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorText = unauthorizedCustomException.Message;
                    break;
                case DefaultInternalServerErorr defaultInternalServerErorr:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorText = defaultInternalServerErorr.Message;
                    break;

                default:
                    break;
            }

            // log any error here to database or file etc..
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(errorText)));
        }
    }
}