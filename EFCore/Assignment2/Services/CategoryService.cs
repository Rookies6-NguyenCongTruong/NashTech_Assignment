using Assignment1.Repositories;
using Assignment2.DTOs.Category;
using Assignment2.Models;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public AddCategoryResponse? Create(AddCategoryRequest createModel)
    {
        using (var transaction = _categoryRepository.DatabaseTransaction())
        {
            try
            {
                var createCategory = new Category
                {
                    CategoryName = createModel.CategoryName
                };

                var category = _categoryRepository.Create(createCategory);

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return new AddCategoryResponse
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                };
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }
    }

    public bool Delete(int id)
    {
        using (var transaction = _categoryRepository.DatabaseTransaction())
        {
            try
            {
                var deleteCategory = _categoryRepository.Get(c => c.Id == id);

                if (deleteCategory != null)
                {
                    bool result = _categoryRepository.Delete(deleteCategory);

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return result;
                }

                return false;
            }
            catch
            {
                transaction.RollBack();

                return false;
            }
        }
    }

    public IEnumerable<GetCategoryResponse> GetAll()
    {
        var list = _categoryRepository.GetAll().Select(category => new GetCategoryResponse
        {
            CategoryId = category.Id,
            CategoryName = category.CategoryName
        });

        return list;
    }

    public GetCategoryResponse? GetById(int id)
    {
        var requestCategory = _categoryRepository.Get(p => p.Id == id);

        if (requestCategory != null)
        {
            return new GetCategoryResponse
            {
                CategoryId = requestCategory.Id,
                CategoryName = requestCategory.CategoryName
            };
        }

        return null;
    }

    public UpdateCategoryResponse? Update(UpdateCategoryRequest updateModel)
    {
        using (var transaction = _categoryRepository.DatabaseTransaction())
        {
            try
            {
                var category = _categoryRepository.Get(c => c.Id == updateModel.Id);

                if (category != null)
                {
                    category.CategoryName = updateModel.CategoryName;

                    var updatedCategory = _categoryRepository.Update(category);

                    _categoryRepository.SaveChanges();

                    transaction.Commit();

                    return new UpdateCategoryResponse
                    {
                        CategoryId = updatedCategory.Id,
                        CategoryName = updatedCategory.CategoryName
                    };
                }

                return null;
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }
    }
}