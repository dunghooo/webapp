using crud.Models;
using crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext _db, IWebHostEnvironment webHostEnvironment)
        {
            db = _db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var result = db.products.ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageUrl == null)
            {
                ModelState.AddModelError("ImageUrl", "Image URL is required.");
            }
            if (ModelState.IsValid)
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(productDto.ImageUrl!.FileName);
                string imagefullPath = _webHostEnvironment.WebRootPath + "/Products/" + newFileName;
                using (var fileStream = System.IO.File.Create(imagefullPath))
                {
                    productDto.ImageUrl.CopyTo(fileStream);
                }
                Product product = new Product()
                {
                    Brand = productDto.Brand,
                    Category = productDto.Category,
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Price = productDto.Price,
                    ImageUrl = newFileName,
                    CreatedAt = DateTime.Now
                };
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var product = db.products.Find(id);

            if (product == null)
            {
                return RedirectToAction("index", "Product");
            }
            ProductDto productDto = new ProductDto()
            {
                Brand = product.Brand,
                Category = product.Category,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            ViewData["ProductId"] = product.Id;
            ViewData["ImageUrl"] = product.ImageUrl;
            ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");

            return View(productDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductDto productDto)
        {
            var product = db.products.Find(id);

            if (product == null)
            {
                return RedirectToAction("index", "Product");
            }
            if (!ModelState.IsValid)
            {
                ViewData["ProductId"] = product.Id;
                ViewData["ImageUrl"] = product.ImageUrl;
                ViewData["CreatedAt"] = product.CreatedAt.ToString("dd/MM/yyyy");
                return View(productDto);
            }

            if (productDto.ImageUrl != null && productDto.ImageUrl.Length > 0)
            {
                // Nếu có file ảnh mới, xử lý lưu ảnh và xóa ảnh cũ
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") +
                                     Path.GetExtension(productDto.ImageUrl.FileName);
                string imageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Products", newFileName);

                using (var fileStream = System.IO.File.Create(imageFullPath))
                {
                    productDto.ImageUrl.CopyTo(fileStream);
                }

                // Xóa ảnh cũ nếu tồn tại
                string oldImageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Products", product.ImageUrl);
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }

                product.ImageUrl = newFileName;
            }
            product.Brand = productDto.Brand;
            product.Category = productDto.Category;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            db.products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = db.products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            // Xóa ảnh nếu tồn tại
            string imageFullPath = Path.Combine(_webHostEnvironment.WebRootPath, "Products", product.ImageUrl);
            if (System.IO.File.Exists(imageFullPath))
            {
                System.IO.File.Delete(imageFullPath);
            }
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index","Product");
        }
    } 
}
