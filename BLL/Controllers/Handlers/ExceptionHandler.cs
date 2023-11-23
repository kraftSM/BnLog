using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BnLog.VAL.Exceptions;

namespace BnLog.BLL.Controllers.Handlers
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
        {
        public void OnException ( ExceptionContext context )
            {

            string onCustomExceptionMESSAGE = "Произошла непредвиденная ошибка. Мы пытаемся её исправить.";

            if (context.Exception is CustomException)
                {
				onCustomExceptionMESSAGE = context.Exception.Message;
                }

            context.Result = new BadRequestObjectResult(onCustomExceptionMESSAGE);

            }
        }
    }
