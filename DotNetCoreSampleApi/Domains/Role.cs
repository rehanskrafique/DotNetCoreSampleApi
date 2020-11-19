using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class Role
    {
        [Key, Column(Order = 0)]
        public Guid RoleId { get; set; }

        [Column(Order = 1, TypeName = "varchar(15)")]
        [Required(ErrorMessage = "You should fill out a name.")]
        public string Name { get; set; }

        [Column(Order = 2, TypeName = "varchar(15)")]
        [Required(ErrorMessage = "You should fill out a normalized name.")]
        public string NormalizedName { get; set; }
    }
}