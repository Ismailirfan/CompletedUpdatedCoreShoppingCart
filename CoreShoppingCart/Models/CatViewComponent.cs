using CoreShoppingCart.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CoreShoppingCart.Models
{
    public class CatViewComponent:ViewComponent
    {
        SCartDbContext db;
        public CatViewComponent(SCartDbContext dbc)
        {
            db = dbc;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await db.Categories.ToListAsync());
        }
    }
}
