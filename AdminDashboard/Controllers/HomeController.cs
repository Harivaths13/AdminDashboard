using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminDashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardViewModel();
            return View(model);
        }

        public IActionResult Widgets()
{
    return View();
}

public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}