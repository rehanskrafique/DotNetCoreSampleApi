using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSampleApi.Contracts
{
    public class AuthDto
    {
        [Required(ErrorMessage = "You should fill out a user name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You should fill out a password.")]
        public string Password { get; set; }

        public string IPAddress { get; set; }

        public string UserAgent { get; set; }
    }
}