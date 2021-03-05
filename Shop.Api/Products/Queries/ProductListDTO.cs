using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Shop.Api.Mappings;
using Shop.Api.Models;

namespace Shop.Api.Products.Queries
{
    public class ProductDTO : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDTO>().ForMember(d => d.ProductImage, opt => opt.MapFrom(s => s.ProductImages.FirstOrDefault().ImageName));
        }
    }
    public class ProductListDTO
    {
        public IList<ProductDTO> Products { get; set; }
    }
}