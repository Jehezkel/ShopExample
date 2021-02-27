using System.Collections.Generic;

namespace Shop.Api.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        public decimal TotalAmount { get; set; }
    }
}