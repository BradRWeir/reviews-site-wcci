using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using template_csharp_reviews_site.Models;

namespace template_csharp_reviews_site.Controllers
{
    public class ReviewController : Controller
    {
        private ApplicationContext _context;

        public ReviewController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            //List<Review> reviewsToDelete = _context.Reviews.Where(r => r.ProductId == 0).ToList();
            //_context.Reviews.RemoveRange(reviewsToDelete);
            //_context.SaveChanges();

            ViewBag.cellPhones = _context.Products.ToList();
            return View(_context.Reviews.ToList());
        }

        public IActionResult Detail(int id)
        {
            Review review = _context.Reviews.Find(id);
            ViewBag.cellPhone = _context.Products.Find(review.ProductId);
            return View(review);
        }

        public IActionResult Add(int id)
        {
            Product product = _context.Products.Find(id);
            ViewBag.Product = product;
            return View(new Review() { ProductId = id });

        }

         [HttpPost]
        public IActionResult Add(Review review)
        {
            review.ReviewDate=System.DateTime.Now;
            _context.Reviews.Add(review);
            _context.SaveChanges();

            return RedirectToAction("Detail","Product",new { id = review.ProductId});

        }

        public IActionResult Edit(int id)
        {
            Review selectReview = _context.Reviews.Find(id);
            return View(selectReview);


        }

       [HttpPost]
        public IActionResult Edit(int id,Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();

            return RedirectToAction("Detail","Product",new {id = review.ProductId});
        }

        public IActionResult Delete(int id)
        {
            Review reviewToDelete = _context.Reviews.Find(id);
            _context.Reviews.Remove(reviewToDelete);
            _context.SaveChanges();
            return RedirectToAction("Detail", "Product", new { id = reviewToDelete.ProductId });
        }


    }


}
   


