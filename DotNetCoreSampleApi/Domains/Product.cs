using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class Product : DomainBase
    {
        //[Key]
        [Key, Column(Order = 0)]
        public Guid ProductId { get; set; }

        [Column(Order = 1, TypeName = "varchar(50)")]
        [Required(ErrorMessage = "You should fill out a user name.")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "You should fill out a category.")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}