using System.Collections.Generic;

namespace Shop.Api.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public AppUser AppUser { get; set; }
        public bool isFinalized { get; set; }
        public ICollection<BasketItem> BasketItems { get; private set; } = new List<BasketItem>();

    }
}