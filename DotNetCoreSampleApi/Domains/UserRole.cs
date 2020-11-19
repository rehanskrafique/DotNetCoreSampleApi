using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class UserRole
    {
        [Key, Column(Order = 0)]
        public Guid UserRoleId { get; set; }

        [Column(Order = 1)]
        [Required]
        public Guid UserId { get; set; }

        [Column(Order = 2)]
        [Required]
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}