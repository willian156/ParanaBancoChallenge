

namespace Customer.API.Models
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public string Message { get; set; }
        public object? Details { get; set; }
    }
}
