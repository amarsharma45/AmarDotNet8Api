using AmarDotNet8Api.Models;
using AmarDotNet8Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmarDotNet8Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = _service.GetById(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _service.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        if (!_service.Update(id, product)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id)) return NotFound();
        return NoContent();
    }
}
