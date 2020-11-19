using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSampleApi.Domains
{
    public abstract class DomainBase
    {
        protected DomainBase()
        {
            CreatedOnUtc = DateTime.UtcNow;
            IsActive = true;
        }
        
        [ForeignKey("CreatedByUser")]
        public Guid CreatedBy { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime CreatedOnUtc { get; set; }

        [ForeignKey("LastModifiedByUser")]
        public Guid? LastModifiedBy { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedOnUtc { get; set; }
        public bool IsActive { get; set; }

        public User CreatedByUser { get; set; }

        public User LastModifiedByUser { get; set; }



    }
}