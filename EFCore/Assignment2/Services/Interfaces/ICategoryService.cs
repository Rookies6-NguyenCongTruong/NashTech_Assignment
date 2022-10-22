using Assignment2.DTOs.Category;

namespace Assignment2.Services.Interfaces;

public interface ICategoryService
{
    AddCategoryResponse? Create(AddCategoryRequest createModel);
    IEnumerable<GetCategoryResponse> GetAll();
    GetCategoryResponse? GetById(int id);
    UpdateCategoryResponse? Update(int id, UpdateCategoryRequest updateModel);
    bool Delete(int id);
}