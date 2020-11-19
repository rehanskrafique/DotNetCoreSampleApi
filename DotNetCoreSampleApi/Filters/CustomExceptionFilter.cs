using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace DotNetCoreSampleApi.Filters
{
    public class CustomExceptionFilter : IFilterMetadata
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.NotImplemented;
            }
            //else if (exceptionType == typeof(MyAppException))
            //{
            //    message = context.Exception.ToString();
            //    status = HttpStatusCode.InternalServerError;
            //}
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            context.ExceptionHandled = true;

            //HttpResponse response = context.HttpContext.Response;
            //response.StatusCode = (int)status;
            //response.ContentType = "application/json";
            //var err = message + " " + context.Exception.StackTrace;
            //response.WriteAsync(err);


            context.Result = new BadRequestObjectResult(new ApiResponse { Code = Enums.StatusCodes.BadRequest, Message = "Validation error(s)." });
            return;
        }
    }
}
