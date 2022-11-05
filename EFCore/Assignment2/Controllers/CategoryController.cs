using Assignment2.DTOs.Category;
using Assignment2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public AddCategoryResponse? Add([FromBody] AddCategoryRequest addCategoryRequest)
    {
        return _categoryService.Create(addCategoryRequest);
    }

    [HttpGet]
    public IEnumerable<GetCategoryResponse> GetAll()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id}")]
    public GetCategoryResponse? GetById(int id)
    {
        return _categoryService.GetById(id);
    }

    [HttpPut]
    public UpdateCategoryResponse? Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        return _categoryService.Update(updateCategoryRequest);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _categoryService.Delete(id);
    }
}