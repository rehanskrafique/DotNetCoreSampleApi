using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Filters
{
    //public sealed class ValidateModelStateAttribute : ActionFilterAttribute
    //{
    //    public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        var exceptionType = context.Exception.GetType();
    //        if (!context.ModelState.IsValid)
    //        {
    //            var errorsInModelState = context.ModelState
    //                .Where(x => x.Value.Errors.Count > 0)
    //                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

    //            List<string> errors = new List<string>();

    //            foreach (var error in errorsInModelState)
    //            {
    //                foreach (var subError in error.Value)
    //                {
    //                    errors.Add(subError);
    //                }
    //            }

    //            context.Result = new BadRequestObjectResult(new ApiResponse { Code = StatusCodes.BadRequest, Message = "Validation error(s).", Result = errors });

    //            return;
    //        }

    //        await next();
    //    }
    //}
}