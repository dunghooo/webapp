using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProductController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var result = db.products.ToList();
            return View(result);
        }
    }
}
