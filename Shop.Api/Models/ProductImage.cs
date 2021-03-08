namespace Shop.Api.Models
{
    public class ProductImage : BaseEntity
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public bool IsMainImage { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}