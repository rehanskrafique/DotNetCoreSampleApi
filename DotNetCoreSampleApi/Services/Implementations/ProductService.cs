using AutoMapper;
using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Data;
using DotNetCoreSampleApi.Domains;
using DotNetCoreSampleApi.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProductService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse> AddProductAsync(ProductDto productDto)
        {
            productDto.Id = Guid.NewGuid();
            Product product = _mapper.Map<Product>(productDto);

            await _context.Database.ExecuteSqlRawAsync("SaveProduct",
                    new SqlParameter("Name", productDto.Name),
                    new SqlParameter("UserId", productDto.UserId));


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new ApiResponse { Code = StatusCodes.Ok, Message = "Product added successfully.", Result = productDto };
        }

        public Task<ApiResponse> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetProductsAsync()
        {
            //_context.Database.From <Market>("SELECT * FROM Market").ToList().Count();
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateProductAsync(Guid id, ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
