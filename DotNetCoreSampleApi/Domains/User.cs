using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class User : DomainBase
    {
        [Key, Column(Order = 0)]
        public Guid UserId { get; set; }

        [Column(Order = 1, TypeName = "varchar(10)")]
        [Required(ErrorMessage = "You should fill out a user name.")]
        public string UserName { get; set; }

        [Column(Order = 2, TypeName = "varchar(10)")]
        [Required(ErrorMessage = "You should fill out a password.")]
        public string Password { get; set; }

        [Column(Order = 3, TypeName = "varchar(60)")]
        [Required(ErrorMessage = "You should fill out a name.")]
        public string Name { get; set; }

        [Column(Order = 4, TypeName = "varchar(50)")]
        [Required(ErrorMessage = "You should fill out a email id.")]
        public string EmailId { get; set; }

        [Column(Order = 5, TypeName = "varchar(15)")]
        [Required(ErrorMessage = "You should fill out a contact number.")]
        public string ContactNumber { get; set; }
    }
}