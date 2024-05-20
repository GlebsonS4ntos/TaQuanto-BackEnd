using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TaQuanto.Domain.Exception;

namespace TaQuanto.Application.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TaQuantoException)
            {
                ThrowTaQuantoException(context);
            }
            else
            {
                ThrowUnknownException(context);
            }
        }

        private void ThrowTaQuantoException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                ThrowNotFoundException(context);
            }
            else if (context.Exception is ValidationException)
            {
                ThrowValidationException(context);
            }
            else if (context.Exception is HeaderIdException)
            {
                ThrowHeaderIdException(context);
            }
            else if (context.Exception is RestrictDeleteException)
            {
                ThrowRestrictDeleteException(context);
            }
        }

        private void ThrowUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorJsonResponse("Erro Interno no Servidor"));
        }

        private void ThrowRestrictDeleteException(ExceptionContext context)
        {
            var exception = context.Exception as RestrictDeleteException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorJsonResponse(exception.Error));
        }

        private void ThrowValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorJsonResponse(exception.Errors));
        }

        private void ThrowHeaderIdException(ExceptionContext context)
        {
            var exception = context.Exception as HeaderIdException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorJsonResponse(exception.Error));
        }

        private void ThrowNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new ObjectResult(new ErrorJsonResponse(exception.Error));
        }
    }
}