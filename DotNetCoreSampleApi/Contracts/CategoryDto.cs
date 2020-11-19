using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreSampleApi.Contracts
{
    public class CategoryDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "You should fill out a name.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {1} --- {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? ParentId { get; set; }

        public Guid UserId { get; set; }
    }
}