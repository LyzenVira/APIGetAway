using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace Aggregation.Models
{
    public class ResponseEntity<TResult> : ResponseEntity
    {
        public ResponseEntity(HttpStatusCode httpStatusCode, TResult result) : base(httpStatusCode)
        {
            Result = result;
        }

        public TResult? Result { get; set; }
    }

    public class ResponseEntity
    {
        public ResponseEntity(HttpStatusCode httpStatusCode)
        {
            StatusCode = (int)httpStatusCode;
        }

        public ResponseEntity(HttpStatusCode httpStatusCode, IEnumerable<Error> errors)
        {
            StatusCode = (int)httpStatusCode;
            Errors = errors;
        }

        public ResponseEntity(int statusCode, IEnumerable<Error>? errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        public int StatusCode { get; set; }

        public IEnumerable<Error>? Errors { get; set; }
    }
}
