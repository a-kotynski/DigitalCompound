using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCompoundAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet("all")]
    public string GetProducts()
    {
        return "returns a list of products";
    }

    [HttpGet("single/{id}")]
    public string GetProduct(int id)
    {
        return "returns a product";
    }
}