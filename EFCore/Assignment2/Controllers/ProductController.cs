using Assignment2.DTOs.Product;
using Assignment2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public AddProductResponse? Add([FromBody] AddProductRequest addProductRequest)
    {
        return _productService.Create(addProductRequest);
    }

    [HttpGet]
    public IEnumerable<GetProductResponse> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id}")]
    public GetProductResponse? GetById(int id)
    {
        return _productService.GetById(id);
    }

    [HttpPut]
    public UpdateProductResponse? Update([FromBody] UpdateProductRequest updateProductRequest)
    {
        return _productService.Update(updateProductRequest);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _productService.Delete(id);
    }
}