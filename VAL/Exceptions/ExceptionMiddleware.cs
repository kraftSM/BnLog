using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using BnLog.VAL.Models;
//using NLog.Fluent;


namespace BnLog.VAL.Exceptions
{
    public class ExceptionMiddleware //: IMiddleware
        {
        //private readonly RequestDelegate _requestDelegate;
        //private ILogger<GlobalExceptionMiddleware> _logger;

        //public ExceptionMiddleware ( RequestDelegate requestDelegate, ILogger<GlobalExceptionMiddleware> logger )//
        //    {
        //    _requestDelegate = requestDelegate;
        //    _logger = logger;
        //    }

        public async Task InvokeAsync ( HttpContext context, RequestDelegate requestDelegate )//
            {
            try
                {
                await requestDelegate(context);
                }
            catch (BadHttpRequestException ex)
                {
                var sc = ex.StatusCode;
                await HandleExceptionAsync(context, ex);
                }
            }

        private static Task HandleExceptionAsync ( HttpContext context, Exception ex )
            {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
                {
                error = new
                    {
                    message = "!!! An error occurred while processing your request.",
                    details = ex.Message
                    }
                };

            //return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            return context.Response.WriteAsync(response.error.ToString());
            }

        //public async Task InvokeAsync ( HttpContext context, RequestDelegate next )
        //    {
        //    try
        //        {
        //        await next(context);
        //        }
        //    catch (Exception exception)
        //        {
        //        string errorId = Guid.NewGuid().ToString();
        //        //_logger.LogError(errorId, exception, exception.Message);
        //        //LogContext.PushProperty("StackTrace", exception.StackTrace);
        //        var errorResult = new ErrorResult
        //            {
        //            Source = exception.TargetSite?.DeclaringType?.FullName,
        //            Exception = exception.Message.Trim(),
        //            ErrorId = errorId,
        //            SupportMessage = $"Provide the Error Id: {errorId} to the support team for further analysis."
        //            };
        //        errorResult.Messages.Add(exception.Message);

        //        if (exception is not CustomException && exception.InnerException != null)
        //            {
        //            while (exception.InnerException != null)
        //                {
        //                exception = exception.InnerException;
        //                }
        //            }

        //        switch (exception)
        //            {
        //            case CustomException e:
        //                errorResult.StatusCode = (int)e.StatusCode;
        //                if (e.ErrorMessages is not null)
        //                    {
        //                    errorResult.Messages = e.ErrorMessages;
        //                    }

        //                break;

        //            case KeyNotFoundException:
        //                errorResult.StatusCode = (int)HttpStatusCode.NotFound;
        //                break;

        //            default:
        //                errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
        //                break;
        //            }

        //        //_logger.LogError($"{errorResult.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {errorId}.");
        //        var response = context.Response;
        //        if (!response.HasStarted)
        //            {
        //            response.ContentType = "application/json";
        //            response.StatusCode = errorResult.StatusCode;
        //            await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
        //            }
        //        else
        //            {
        //            //_logger.LogWarning("Can't write error response. Response has already started.");
        //            }
        //        }
        //    }

        }
    
}
