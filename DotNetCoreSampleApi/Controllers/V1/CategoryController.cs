using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Enums;
using DotNetCoreSampleApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCoreSampleApi.Controllers.V1
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [Route("api/v1/categories/test")]
        public ActionResult GetTest()
        {
            _logger.LogInformation("Inside test method");
            return Ok("Function called");
        }

        [Authorize]
        [HttpPost]
        [Route("api/v1/categories")]
        public async Task<ActionResult<ApiResponse>> Post([FromBody] CategoryDto categoryDto)
        {
            try
            {
                categoryDto.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var apiResponse = await _categoryService.AddCategoryAsync(categoryDto);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/categories")]
        public async Task<ActionResult<ApiResponse>> Put(Guid id, [FromBody] CategoryDto categoryDto)
        {
            try
            {
                categoryDto.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var apiResponse = await _categoryService.UpdateCategoryAsync(id, categoryDto);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/categories")]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            try
            {
                var apiResponse = await _categoryService.GetCategoriesAsync();
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/v1/categories/{id}")]
        public async Task<ActionResult<ApiResponse>> GetById(Guid id)
        {
            try
            {
                var apiResponse = await _categoryService.GetCategoryByIdAsync(id);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("api/v1/categories/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete(Guid id)
        {
            try
            {
                Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var apiResponse = await _categoryService.DeactivateCategoryAsync(id, userId);
                return StatusCode((int)apiResponse.Code, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse { Code = StatusCodes.InternalServerError, Message = ex.Message });
            }
        }
    }
}