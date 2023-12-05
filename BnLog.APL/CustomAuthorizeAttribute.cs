using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BnLog.APL
    {
    public class CustomAuthorizeAttribute : TypeFilterAttribute
        {
        public CustomAuthorizeAttribute ( ) : base(typeof(CustomAuthorizeFilter)) //AuthorizeFilter?
            {
            }

        public string Roles { get; set; }

        private class CustomAuthorizeFilter : IAuthorizationFilter
            {
            public void OnAuthorization ( AuthorizationFilterContext context )
                {
                if (!context.HttpContext.User.Identity.IsAuthenticated)
                    {
                    // Пользователь не аутентифицирован, выполните необходимое действие
                    /* context.Result = new ContentResult
                    {
                        Content = "Ошибка доступа. Войдите в систему.",
                        StatusCode = 401
                    }; */
                    context.Result = new RedirectToActionResult("Error", "Error", 401);
                    }
                else if (!context.HttpContext.User.IsInRole("Администратор"))
                    {
                    // Пользователь не имеет нужной роли, выполните необходимое действие
                    context.Result = new ContentResult
                        {
                        Content = "Ошибка доступа. У вас нет необходимых прав.",
                        StatusCode = 403
                        };
                    }
                }
            }
        }
    }
