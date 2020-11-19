using DotNetCoreSampleApi.Contracts;
using System;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services
{
    public interface ICategoryService
    {
        Task<ApiResponse> AddCategoryAsync(CategoryDto categoryDto);
        Task<ApiResponse> UpdateCategoryAsync(Guid id, CategoryDto categoryDto);
        Task<ApiResponse> GetCategoriesAsync();
        Task<ApiResponse> GetCategoryByIdAsync(Guid id);
        Task<ApiResponse> DeactivateCategoryAsync(Guid id, Guid userId);
    }
}