using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Models;
using FIT5032_Assignment_2.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FIT5032_Assignment_2.Controllers
{
    public class OrganisationDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrganisationDetailsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(OrganisationDetails model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    System.Console.WriteLine(model.UserId);
                    _context.OrganisationDetails.Add(model);
                    _context.SaveChanges();
                    ViewBag.Result = "Details have been submitted and project is now up for fund raising!";
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
