using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSampleApi.Contracts
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "You should fill out a user name.")]
        [MaxLength(10, ErrorMessage = "The user name shouldn't have more than 10 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You should fill out a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

        //[MaxLength(10, ErrorMessage = "The password shouldn't have more than 10 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(60, ErrorMessage = "The user name shouldn't have more than 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a email id.")]
        [MaxLength(50, ErrorMessage = "The email id shouldn't have more than 50 characters.")]
        [EmailAddress(ErrorMessage = "You should enter valid email id.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "You should fill out a contact number.")]
        [MaxLength(15, ErrorMessage = "The contact number shouldn't have more than 15 characters.")]
        public string ContactNumber { get; set; }

        public string Role { get; set; }

        public Guid? UserId { get; set; }
    }
}