using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using template_csharp_reviews_site.Models;

namespace template_csharp_reviews_site.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;

        public HomeController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            IOrderedEnumerable<Product> topProducts = _context.Products.ToList()
                .OrderByDescending(p => p.AverageReviewRating);
            return View(topProducts);
        }
    }
}
