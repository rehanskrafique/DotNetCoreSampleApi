using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Contracts
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "You should fill out a name.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {1} --- {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }
        
        public Guid CategoryId { get; set; }
        
        public CategoryDto Category { get; set; }
        
        public Guid UserId { get; set; }
    }
}