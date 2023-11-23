using BnLog.DAL.Models;
using BnLog.Views.StatusCode;
using BnLog.Views;
using System.Diagnostics;
using BnLog.VAL.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BnLog.Pages;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;


namespace BnLog.BLL.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [Route("[controller]")]
    //public class ErrorsController : ControllerBase
    public class ErrorsController : Controller
        {
        private IOptions<ApplConfiguration> _settings;
        private readonly ILogger<ErrorsController> _logger;
        public ErrorsController ( IOptions<ApplConfiguration> settings, ILogger<ErrorsController> logger )
            {
            _settings = settings;
            _logger = logger;
            }
        // <snippet_Throw> Test throw new Exception
        //[HttpGet("Throw")]
        //public IActionResult Throw ( ) =>
        //    throw new Exception("Sample exception.");
        //</snippet_Throw>

        [Route("/Account/AccessDenied")]
        [Route("/error-exp")]

        public IActionResult Error ( )
            {
            int StatusCode = StatusCodes.Status500InternalServerError;


			//		// using static System.Net.Mime.MediaTypeNames;
			//		context.Response.ContentType = Text.Plain;

			//		await context.Response.WriteAsync("An exception was thrown. Lambda CASE");
            // Get the details of the exception that occurred            
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // Get the exceptionFeature are getting
            if (exceptionFeature != null)
                {
                // Get the exception that occurred
                var exError = exceptionFeature.Error;
                var exPath = exceptionFeature.Path;
                var exRouteValues = exceptionFeature.RouteValues;
                var exEndpoint = exceptionFeature.Endpoint;
                // Get which route the exception occurred at
                string routeWhereExceptionOccurred = exceptionFeature.Path;

                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;
                //StatusCode = exceptionThatOccurred.Data.

                _logger.LogError($"ErrorsController.Er00000.TheErrorOnBoard: \t{exceptionFeature.Error.Message}");
                // Get the exception that occurred by Types
                if (exError is AuthenticationException)
                    {
                        StatusCode = 401;
                        _logger.LogError($"ErrorsController.ErAn001.AuthenticationException:{exEndpoint.DisplayName}");

                    return SetErrView(StatusCode);// надо перебросить на 
                        //return ErrorsRedirect(StatusCode);

                    }

                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500

                var errModel = new ErrorViewModel { ErrCode = StatusCode, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
                //errModel.RequestId = 

                return SetErrView( HttpContext.Response.StatusCode);

                }

            // return Common Case Exception
            _logger.LogError($"ErrorsController.ErXXXXX.TheUnknounErrorOnBoard: - [ErrorCode=500]");
            return SetErrView (500);
            }
        // <snippet_ConsistentEnvironments>

        [Route("/error-development")]
        //public IActionResult HandleErrorDevelopment ( [FromServices] IHostEnvironment hostEnvironment, )
        public IActionResult HandleErrorDevelopment ( int? statusCode = null )
            {
            const string viewBaseDir = "Error/";

            if (!_settings.Value.onDevelopmentMode)
            //if (! hostEnvironment.IsDevelopment())
                {
                return NotFound();
                //return SetErrView(500);
                }

            var ErrorInfo = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            if (statusCode.HasValue)
                {
                if (statusCode == 401 || statusCode == 403 || statusCode == 404) //
                    {
                    var stCode = statusCode.ToString();
                    var viewName = viewBaseDir + stCode;
                    //var viewName =  statusCode.ToString();

                    //_logger.LogError($"Home/Error Произошла ошибка - {stCode}\t{viewName}");
                    return SetErrView(statusCode);
                    }
                else
                    {
                    //_logger.LogError($"Home/Error Произошла ошибка - {500}");
                    //return View(viewBaseDir + "500", ErrorInfo); //имеет ли смысл отдавать дот инф. наружу???
                    return SetErrView(500);
                    }
                }
            //var exceptionHandlerFeature =
            //    HttpContext.Features.Get<IExceptionHandlerFeature>();

            return SetErrView(500);
            //return Problem(
            //    detail: exceptionHandlerFeature.Error.StackTrace,
            //    title: exceptionHandlerFeature.Error.Message);
            }

        private IActionResult SetErrView ( int? statusCode = null )
            {
            
            var ErrorInfo = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            if (statusCode.HasValue)
                {
                if (statusCode == 401 || statusCode == 403 || statusCode == 404)
                    {
                    var stCode = statusCode.ToString();
                    return  View(stCode, ErrorInfo);
                    }
                else
                    return View("500", ErrorInfo);
                   
                }
            //Return message by default
            return View("500", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }


        [Route("Errors/{id?}")]
        public async Task<IActionResult> ErrorsRedirect ( int? statusCode = null )
            {
            if (statusCode.HasValue)
                {
                switch (statusCode)
                    {
                    case 400: return RedirectToPage("/Errors/ResourceIsNotFoundPage");
                    case 401: return RedirectToPage("/Errors/AccessIsDeniedPage");
                    default: return RedirectToPage("/Errors/UnknownErrorPage");
                    }
                }
            return RedirectToPage("/Error");
            }

        // <snippet_HandleError>
        //[Route("/error")]
        //public IActionResult HandleError ( ) =>
        //Problem();
        // </snippet_HandleError>
        // </snippet_ConsistentEnvironments>
        }
    }
