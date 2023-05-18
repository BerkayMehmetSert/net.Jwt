using API.Application.Constants.Requests.Products;
using API.Application.Constants.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static API.Application.Constants.Messages.Products.ProductMessage;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateProduct([FromBody] CreateProductRequest request)
    {
        _service.CreateProduct(request);

        return Ok(new
        {
            Success = true,
            Message = ProductCreated
        });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
    {
        _service.UpdateProduct(id, request);

        return Ok(new
        {
            Success = true,
            Message = ProductUpdated
        });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProduct([FromRoute] Guid id)
    {
        _service.DeleteProduct(id);

        return Ok(new
        {
            Success = true,
            Message = ProductDeleted
        });
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult GetProductById([FromRoute] Guid id)
    {
        var product = _service.GetProductById(id);
        
        return Ok(new
        {
            Success = true,
            Message = ProductRetrieved,
            Data = product
        });
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public IActionResult GetAllProducts()
    {
        var products = _service.GetAllProducts();
        
        return Ok(new
        {
            Success = true,
            Message = ProductRetrieved,
            Data = products
        });
    }
}