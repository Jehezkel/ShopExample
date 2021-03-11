using System.Collections.Generic;
using AutoMapper;
using Shop.Api.Mappings;
using Shop.Api.Models;

namespace Shop.Api.Products.Queries.GetProductDetails
{
    public class ProductDetailsDTO : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public string ProductDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsDTO>()
                .ForMember(d => d.ProductDescription, opt => opt.MapFrom(s => s.ProductDescription.Description));
        }
    }
}