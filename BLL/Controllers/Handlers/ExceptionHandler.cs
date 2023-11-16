using BnLog.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BnLog.BLL.Controllers.Handlers
    {
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
        {
        public void OnException ( ExceptionContext context )
            {

            string onCstomCustomExceptionMESSAGE = "Произошла непредвиденная ошибка. Мы пытемся её исправить.";

            if (context.Exception is CustomException)
                {
                onCstomCustomExceptionMESSAGE = context.Exception.Message;
                }

            context.Result = new BadRequestObjectResult(onCstomCustomExceptionMESSAGE);

            }
        }
    }
