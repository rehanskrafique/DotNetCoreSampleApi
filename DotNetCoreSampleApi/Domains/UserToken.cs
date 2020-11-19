using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public class UserToken
    {
        [Key, Column(Order = 0)]
        public Guid UserTokenId { get; set; }
        
        [Column(Order = 1)]
        public Guid UserId { get; set; }

        [Column(Order = 2)]
        [StringLength(450)]
        public string RefreshToken { get; set; }

        [Column(Order = 3)]
        public DateTime IssuedOnUtc { get; set; }

        [Column(Order = 4)]
        public DateTime ExpiresOnUtc { get; set; }

        [Column(Order = 5)]
        public string IPAddress { get; set; }

        [Column(Order = 6)]
        public string UserAgent { get; set; }

        public bool Invalidated { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}