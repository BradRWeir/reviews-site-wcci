using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template_csharp_reviews_site.Models;
using System.Linq;

namespace template_csharp_reviews_site.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationContext _context;

        public ProductController()
        {
            _context = new ApplicationContext();
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Detail(int id)
        {
            Product cellPhone = _context.Products.Find(id);
            if (string.IsNullOrEmpty(cellPhone.Picture))
            {
                cellPhone.Picture = "https://media.istockphoto.com/vectors/smartphone-blank-screen-phone-mockup-template-for-infographics-for-vector-id1192828240?k=20&m=1192828240&s=612x612&w=0&h=A3BgJSW_-u9jOlzIqatYzeSjIgaAbg7eZUlzD-b53Qs=";
            }
            return View(cellPhone);
        }

        public IActionResult Add()
        {
            return View(new Product() { ReleaseDate = System.DateTime.Now });
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(_context.Products.Find(id));
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Detail", new { Id = product.Id });
        }

        public IActionResult Remove(int id)
        {
            _context.Products.Remove(_context.Products.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
