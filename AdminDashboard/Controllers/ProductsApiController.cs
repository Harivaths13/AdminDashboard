using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminDashboard.Models;
using System.Text.Json;
using System.Text;

namespace AdminDashboard.Controllers;

[ApiController]
[IgnoreAntiforgeryToken]
[Route("api/[controller]")]
public class ProductsApiController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ProductsApiController(ApplicationDBContext context)
    {
        _context = context;
    }

    // GET: api/productsapi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        return Ok(products);
    }

    // GET: api/productsapi/download
    [HttpGet("download")]
    public async Task<IActionResult> DownloadJson()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(products, jsonOptions);
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
        string fileName = $"products_export_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
        return File(byteArray, "application/json", fileName);
    }

    // POST: api/productsapi
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
    {
        if (dto == null)
        {
            return BadRequest(new { message = "Invalid product data received." });
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest(new { message = "Product name is required." });
        }

        if (dto.Price < 0 || dto.StockQuantity < 0)
        {
            return BadRequest(new { message = "Price and stock quantity must be zero or positive." });
        }

        try
        {
            var product = new Product
            {
                Name = dto.Name.Trim(),
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.InnerException?.Message ?? ex.Message });
        }
    }

    // DELETE: api/productsapi/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(new { message = $"Product with ID {id} was not found." });
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

public class ProductCreateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}