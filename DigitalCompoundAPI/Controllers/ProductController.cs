using System.Diagnostics.CodeAnalysis;
using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCompoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;
    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _repository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("single/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("all/brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _repository.GetProductBrandsAsync();
        return Ok(productBrands);
    }

    [HttpGet("all/types")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
    {
        var productTypes = await _repository.GetProductTypesAsync();
        return Ok(productTypes);
    }

}