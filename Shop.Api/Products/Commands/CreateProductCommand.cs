using System.Net.Cache;
using System.Threading;
using System.Reflection.Metadata;
using System.Collections.Generic;
using MediatR;
using Shop.Api.DAL;
using Shop.Api.Models;
using System.Threading.Tasks;

namespace Shop.Api.Products.Commands
{
    public class AddedImageDTO
    {
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public bool IsMainImage { get; set; }
    }
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public List<AddedImageDTO> Images { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                Price = request.Price
            };
            request.Images.ForEach(async i =>
            {
                var currImage = await _context.ProductImages.FindAsync(i.ProductImageId);
                currImage.IsMainImage = i.IsMainImage;
                product.ProductImages.Add(currImage);
            });
            _context.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.ProductId;
        }
    }
}