using CoreShoppingCart.Areas.Identity.Data;
using CoreShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace CoreShoppingCart.Controllers
{
    public class HomeController : Controller
    {

        ////private readonly ILogger<HomeController> _logger;
        SCartDbContext db;
        public HomeController(SCartDbContext scc)
        {
            db = scc;
        }

        //public IActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}
        public async Task<IActionResult> Index(string categorySlug = "")
        {
            ViewBag.CategorySlug = categorySlug;
            if (categorySlug == "")
            {
                return View(await db.Products.OrderByDescending(p => p.Pid).ToListAsync());
            }
            else
            {
                Category category = await db.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
                if (category == null) return RedirectToAction("Index");
                var productsByCategory = db.Products.Where(p => p.CategoryId == category.CategoryId);
                return View(await productsByCategory.OrderByDescending(p => p.Pid).ToListAsync());
            }
        }

        public IActionResult Privacy()
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