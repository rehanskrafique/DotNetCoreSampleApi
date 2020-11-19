using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class Category : DomainBase
    {
        [Key, Column(Order = 0)]
        public Guid CategoryId { get; set; }

        [Column(Order = 1, TypeName = "varchar(50)")]
        [Required(ErrorMessage = "You should fill out a name.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("ParentCategory")]
        public Guid? ParentId { get; set; }
        
        public Category ParentCategory { get; set; }
    }
}