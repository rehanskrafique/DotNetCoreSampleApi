﻿using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Filters
{
    public sealed class CustomAuthorizeFilter : AuthorizeAttribute
    {
        public new AuthorizationPolicy Policy { get; }

        public CustomAuthorizeFilter(AuthorizationPolicy policy)
        {
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizeResult = await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

            if (authorizeResult.Challenged)
            {
                // Return custom 401 result
                //context.Result = new CustomUnauthorizedResult("Authorization failed.");

                context.Result = new BadRequestObjectResult(new ApiResponse { Code = StatusCodes.UnAuthorized, Message = "Authorization failed" });
            }
            else if (authorizeResult.Forbidden)
            {
                // Return default 403 result
                //context.Result = new ForbidResult(Policy.AuthenticationSchemes.ToArray());

                context.Result = new BadRequestObjectResult(new ApiResponse { Code = StatusCodes.UnAuthorized, Message = "Authorization failed" });
            }
        }








        //protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        //{

        //}

        //public AuthorizationPolicy Policy { get; }

        //public CustomAuthorizeFilter(AuthorizationPolicy policy)
        //{
        //    Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        //}

        //public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException(nameof(context));
        //    }

        //    // Allow Anonymous skips all authorization
        //    //if (context.Filters.Any(item = &amp; gt; item is IAllowAnonymousFilter))
        //    //{
        //    //    return;
        //    //}

        //    //var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService &amp; lt; IPolicyEvaluator & amp; gt; ();
        //    //var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
        //    var authorizeResult = await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

        //    if (authorizeResult.Challenged)
        //    {
        //        // Return custom 401 result
        //        context.Result = new CustomUnauthorizedResult("Authorization failed.");
        //    }
        //    else if (authorizeResult.Forbidden)
        //    {
        //        // Return default 403 result
        //        context.Result = new ForbidResult(Policy.AuthenticationSchemes.ToArray());
        //    }
        //}
    }
}
