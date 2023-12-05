﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace BnLog.VAL.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        public async Task InvokeAsync(HttpContext context, Func<Task> next)
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                error = new
                {
                    message = "An error occurred while processing your request.",
                    details = ex.Message
                }
            };

            //return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            return context.Response.WriteAsync(response.error.ToString());
        }
    }
}