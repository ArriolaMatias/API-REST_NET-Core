using System.Net;

namespace Entities
{
    public class csResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

    }
}
