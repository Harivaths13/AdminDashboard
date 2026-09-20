using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminDashboard.Models;

namespace AdminDashboard.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDBContext _context;

    public HomeController(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var totalProducts = await _context.Products.CountAsync();
        var productList = await _context.Products.ToListAsync();

        ViewBag.Products = productList;

        var model = new DashboardViewModel
        {
            NewOrders = totalProducts, // displaying product count
            BounceRate = 12,
            UserRegistrations = 44,
            UniqueVisitors = 65
        };

        return View(model);
    }

    // --- ADDED METHOD HERE ---
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
    // -------------------------

    public IActionResult Widgets() => View();
    public IActionResult Charts() => View();
    public IActionResult Tables() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}