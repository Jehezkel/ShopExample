namespace Shop.Api.Models
{
    public class ProductImage : BaseEntity
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageExtension { get; set; }
        public bool IsMainImage { get; set; }
    }
}