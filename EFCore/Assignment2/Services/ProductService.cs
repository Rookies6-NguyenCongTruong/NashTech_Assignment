using Assignment1.Repositories;
using Assignment2.DTOs.Product;
using Assignment2.Models;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public AddProductResponse? Create(AddProductRequest createModel)
    {
        using (var transaction = _productRepository.DatabaseTransaction())
        {
            try
            {
                var category = _categoryRepository.Get(s => s.Id == createModel.CategoryId);

                if (category != null)
                {
                    var createProduct = new Product
                    {
                        ProductName = createModel.ProductName,
                        Manufacture = createModel.Manufacture,
                        CategoryId = category.Id,
                    };

                    var product = _productRepository.Create(createProduct);

                    _productRepository.SaveChanges();

                    transaction.Commit();

                    return new AddProductResponse
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Manufacture = product.Manufacture,
                        CategoryId = product.CategoryId
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

    public bool Delete(int id)
    {
        using (var transaction = _productRepository.DatabaseTransaction())
        {
            try
            {
                var deleteProduct = _productRepository.Get(p => p.Id == id);

                if (deleteProduct != null)
                {
                    bool result = _productRepository.Delete(deleteProduct);

                    _productRepository.SaveChanges();

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

    public IEnumerable<GetProductResponse> GetAll()
    {
        var list = _productRepository.GetAll(p => true).Select(product => new GetProductResponse
        {
            ProductId = product.Id,
            ProductName = product.ProductName,
            Manufacture = product.Manufacture,
            CategoryId = product.CategoryId
        });

        return list;
    }

    public GetProductResponse? GetById(int id)
    {
        var requestProduct = _productRepository.Get(p => p.Id == id);

        if (requestProduct != null)
        {
            return new GetProductResponse
            {
                ProductId = requestProduct.Id,
                ProductName = requestProduct.ProductName,
                Manufacture = requestProduct.Manufacture,
                CategoryId = requestProduct.CategoryId
            };
        }

        return null;
    }

    public UpdateProductResponse? Update(int id, UpdateProductRequest updateModel)
    {
        using (var transaction = _productRepository.DatabaseTransaction())
        {
            try
            {
                var product = _productRepository.Get(p => p.Id == id);

                if (product != null)
                {
                    var category = _categoryRepository.Get(c => c.Id == updateModel.CategoryId);

                    if (category != null)
                    {
                        product.ProductName = updateModel.ProductName;
                        product.Manufacture = updateModel.Manufacture;
                        product.CategoryId = updateModel.CategoryId;

                        var updatedProduct = _productRepository.Update(product);

                        _productRepository.SaveChanges();

                        transaction.Commit();

                        return new UpdateProductResponse
                        {
                            ProductId = updatedProduct.Id,
                            ProductName = updatedProduct.ProductName,
                            Manufacture = updatedProduct.Manufacture,
                            CategoryId = updatedProduct.CategoryId
                        };
                    }

                    return null;
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