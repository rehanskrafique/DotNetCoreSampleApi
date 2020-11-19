namespace DotNetCoreSampleApi.Contracts
{
    public class RefreshTokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
    }
}