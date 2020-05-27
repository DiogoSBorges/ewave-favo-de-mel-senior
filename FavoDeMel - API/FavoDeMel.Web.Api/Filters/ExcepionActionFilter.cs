
using FavoDeMel.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FavoDeMel.Api.Filter
{
    public class ExcepionActionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json; charset=utf-8";

            if (context.Exception is AppException || context.Exception is ArgumentException)
            {
                response.StatusCode = (int) HttpStatusCode.BadRequest;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(context.Exception.Message);
        }
    }
}
