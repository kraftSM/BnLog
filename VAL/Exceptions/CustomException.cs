using System.Net;

namespace BnLog.VAL.Exceptions
    {
    public class CustomException : Exception
        {
        public List<string>? ErrorMessages { get; }

        public HttpStatusCode StatusCode { get; }

        public CustomException ( string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError )
            : base(message)
            {
            ErrorMessages = errors;
            StatusCode = statusCode;
            }
        }
    public class NotFoundException : CustomException
        {
        public NotFoundException ( string message )
            : base(message, null, HttpStatusCode.NotFound)
            {
            }
        }
    public class InternalServerException : CustomException
        {
        public InternalServerException ( string message, List<string>? errors = default )
            : base(message, errors, HttpStatusCode.InternalServerError) { }
        }

    }


