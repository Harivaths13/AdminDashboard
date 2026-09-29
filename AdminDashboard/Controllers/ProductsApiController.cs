using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminDashboard.Models;
using System.Text.Json;
using System.Text;

namespace AdminDashboard.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsApiController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    // 1. Dependency Injection: Visual Studio injects your SQL Server DB context
    public ProductsApiController(ApplicationDBContext context)
    {
        _context = context;
    }

    // 2. View JSON in browser/API consumer
    // URL: GET /api/productsapi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        return Ok(products);
    }

    // 3. Download JSON directly as a file
    // URL: GET /api/productsapi/download
    [HttpGet("download")]
    public async Task<IActionResult> DownloadJson()
    {
        // Fetch all products from SQL Server
        var products = await _context.Products.AsNoTracking().ToListAsync();

        // Convert the C# list into indented, readable JSON text
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(products, jsonOptions);

        // Convert the string into a byte array
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);

        // Prompt the user's browser to save the file
        string fileName = $"products_export_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
        return File(byteArray, "application/json", fileName);
    }
}