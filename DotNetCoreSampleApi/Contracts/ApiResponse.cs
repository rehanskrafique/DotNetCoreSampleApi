using DotNetCoreSampleApi.Enums;

namespace DotNetCoreSampleApi.Contracts
{
    public class ApiResponse
    {
        public StatusCodes Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}