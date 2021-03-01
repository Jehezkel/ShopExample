using System.Collections.Generic;

namespace Shop.Api.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public bool MyProperty { get; set; }
    }
}