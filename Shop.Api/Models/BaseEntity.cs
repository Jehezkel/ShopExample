using System;

namespace Shop.Api.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}