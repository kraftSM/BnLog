using BnLog.DAL.Models;
using BnLog.Views.StatusCode;
using BnLog.Views;
using System.Diagnostics;
using BnLog.VAL.Configuration.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using BnLog.Pages;
using Microsoft.AspNetCore.Http;

namespace BnLog.BLL.Controllers
	{
	[ApiController]
	[Route("api/[controller]")]
	public class ErrorsController : ControllerBase
		{
		private IOptions<ApplConfiguration> _settings;
        private readonly ILogger<ErrorsController> _logger;
        public ErrorsController ( IOptions<ApplConfiguration> settings, ILogger<ErrorsController> logger )
			{
				_settings = settings;
				_logger = logger;
            }
		// <snippet_Throw>
		[HttpGet("Throw")]
		public IActionResult Throw ( ) =>
			throw new Exception("Sample exception.");
		// </snippet_Throw>
		[Route("/error-exp")]

		public IActionResult Error ( )
		{
			int StatusCode = StatusCodes.Status500InternalServerError;


			//		// using static System.Net.Mime.MediaTypeNames;
			//		context.Response.ContentType = Text.Plain;

			//		await context.Response.WriteAsync("An exception was thrown. Lambda CASE");
			// Get the details of the exception that occurred
			var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			if (exceptionFeature != null)
				{
				// Get which route the exception occurred at
				string routeWhereExceptionOccurred = exceptionFeature.Path;

				// Get the exception that occurred
				Exception exceptionThatOccurred = exceptionFeature.Error;
                _logger.LogError($"ErrorsController Произошла ошибка - {StatusCode}\t{exceptionFeature.Error.Message}");

                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500

                var errModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
				//errModel.RequestId = 

				return View("Error", HttpContext.Response.StatusCode);

				}

			return View("Home/Error", 500);
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
					return View(viewName);
					}
				else
					{
					//_logger.LogError($"Home/Error Произошла ошибка - {500}");
					//return View(viewBaseDir + "500", ErrorInfo); //имеет ли смысл отдавать дот инф. наружу???
					return View(viewBaseDir + "500");
					}
				}
			var exceptionHandlerFeature =
				HttpContext.Features.Get<IExceptionHandlerFeature>()!;

			return Problem(
				detail: exceptionHandlerFeature.Error.StackTrace,
				title: exceptionHandlerFeature.Error.Message);
			}

		private IActionResult View ( string viewName, int? statusCode = null )
			{
			//throw new NotImplementedException();
			return RedirectToAction("Error", "Home");
			}

		// <snippet_HandleError>
		[Route("/error")]
		public IActionResult HandleError ( ) =>
			Problem();
		// </snippet_HandleError>
		// </snippet_ConsistentEnvironments>
		}
	}
