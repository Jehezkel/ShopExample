using System.Net.Mime;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shop.Api.DAL;
using Shop.Api.Models;

namespace Shop.Api.Images.Command
{
    public class UploadImageCommand : IRequest<string>
    {
        public IFormFile UploadedImage { get; set; }
    }
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public UploadImageCommandHandler(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            string uploadPathDest = Path.Combine(this._env.WebRootPath, "images");
            if (!Directory.Exists(uploadPathDest))
            {
                Directory.CreateDirectory(uploadPathDest);
            }
            string tempFileName, fullFilePath;
            do
            {
                tempFileName = Guid.NewGuid() + "_" + request.UploadedImage.FileName;
                fullFilePath = Path.Combine(uploadPathDest, tempFileName);
            } while (File.Exists(fullFilePath));
            using (var stream = System.IO.File.Create(fullFilePath))
            {
                await request.UploadedImage.CopyToAsync(stream);
            }
            var prodImage = new ProductImage
            {
                ImageName = tempFileName
            };
            _context.ProductImages.Add(prodImage);
            await _context.SaveChangesAsync();
            return tempFileName;
        }
    }
}