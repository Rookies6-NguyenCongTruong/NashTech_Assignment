using Assignment2.Models;

namespace Assignment1.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductStoreContext context) : base(context)
    {
    }
}