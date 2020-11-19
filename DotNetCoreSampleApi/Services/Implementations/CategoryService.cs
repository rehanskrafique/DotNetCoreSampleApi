using AutoMapper;
using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Data;
using DotNetCoreSampleApi.Domains;
using DotNetCoreSampleApi.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CategoryService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse> AddCategoryAsync(CategoryDto categoryDto)
        {
            categoryDto.Id = Guid.NewGuid();
            Category category = _mapper.Map<Category>(categoryDto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return new ApiResponse { Code = StatusCodes.Created, Message = "Category added successfully.", Result = categoryDto };
        }

        public async Task<ApiResponse> DeactivateCategoryAsync(Guid id, Guid userId)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiResponse { Code = StatusCodes.NotFound, Message = $"Category id {id} not found." };
            }
            category.IsActive = false;
            category.LastModifiedBy = userId;
            category.LastModifiedOnUtc = DateTime.UtcNow;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return new ApiResponse { Code = StatusCodes.Ok, Message = $"Category id {id} deleted successfully.", Result = category };
        }

        public async Task<ApiResponse> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return categories != null
                    ? new ApiResponse { Code = StatusCodes.Ok, Message = "Categories fetched successfully.", Result = _mapper.Map<IEnumerable<CategoryDto>>(categories) }
                    : new ApiResponse { Code = StatusCodes.NotFound, Message = "Categories not found." };
        }

        public async Task<ApiResponse> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category != null
                    ? new ApiResponse { Code = StatusCodes.Ok, Message = "Category fetch successfully.", Result = _mapper.Map<CategoryDto>(category) }
                    : new ApiResponse { Code = StatusCodes.NotFound, Message = $"Category id {id} not found." };
        }

        public async Task<ApiResponse> UpdateCategoryAsync(Guid id, CategoryDto categoryDto)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiResponse { Code = StatusCodes.NotFound, Message = $"Category id {id} not found." };
            }
            category.LastModifiedOnUtc = DateTime.UtcNow;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return new ApiResponse { Code = StatusCodes.Ok, Message = $"Category id {id} updated successfully.", Result = category };
        }
    }
}