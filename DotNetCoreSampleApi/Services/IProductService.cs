using DotNetCoreSampleApi.Contracts;
using System;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services
{
    public interface IProductService
    {
        Task<ApiResponse> AddProductAsync(ProductDto productDto);
        Task<ApiResponse> UpdateProductAsync(Guid id, ProductDto productDto);
        Task<ApiResponse> GetProductsAsync();
        Task<ApiResponse> GetProductByIdAsync(Guid id);
        Task<ApiResponse> DeleteProductAsync(Guid id);
    }
}