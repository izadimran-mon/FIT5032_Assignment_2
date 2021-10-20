using FIT5032_Assignment_2.Data;
using FIT5032_Assignment_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Controllers
{
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public RatingController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rating.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    //System.Console.WriteLine(rating.Rating_Score);
                    _context.Rating.Add(rating);
                    _context.SaveChanges();
                    TempData["Result"] = "Thank you for rating this app!";
                    ModelState.Clear();
                }
                catch
                {
                    return View("Index");

                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
