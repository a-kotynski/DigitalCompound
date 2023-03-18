using System.Security.Cryptography;
using DigitalCompoundAPI.Data;
using DigitalCompoundAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalCompoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DigitalCompoundDbContext _dbContext;
    public ProductController(DigitalCompoundDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products;
    }

    [HttpGet("single/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return product;
    }
}