using DigitalCompoundCore.Entities;
using DigitalCompoundCore.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCompoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IGenericRepository<Product> _productsRepository;
    private readonly IGenericRepository<ProductBrand> _productBrandRepository;
    private readonly IGenericRepository<ProductType> _productTypeRepository;

    public ProductController(
    IGenericRepository<Product> productsRepository, 
    IGenericRepository<ProductBrand> productBrandRepository,
    IGenericRepository<ProductType> productTypeRepository)
    {
        _productsRepository = productsRepository;
        _productBrandRepository = productBrandRepository;
        _productTypeRepository = productTypeRepository;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _productsRepository.ListAllAsync();
        return Ok(products);
    }

    [HttpGet("single/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("all/brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _productBrandRepository.ListAllAsync();
        return Ok(productBrands);
    }

    [HttpGet("all/types")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
    {
        var productTypes = await _productTypeRepository.ListAllAsync();
        return Ok(productTypes);
    }
}