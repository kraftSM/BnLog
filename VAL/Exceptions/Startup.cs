namespace BnLog.VAL.Exceptions
    {
    public static class Startup
        {
        public static IApplicationBuilder UseGlobalExceptionHandler ( this IApplicationBuilder app )
            => app.UseMiddleware<ExceptionMiddleware>();
         
        }
    }
