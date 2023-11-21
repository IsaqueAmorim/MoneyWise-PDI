using System.Net;

namespace MoneyWise.Dominio
{
    public class HttpExceptionExtensions : Exception
    {
        public HttpExceptionExtensions() 
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
