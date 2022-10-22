using Assignment2.Models;

namespace Assignment1.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductStoreContext context) : base(context)
    {
    }
}