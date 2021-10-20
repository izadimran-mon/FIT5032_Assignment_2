using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FIT5032_Assignment_2.Models;

namespace FIT5032_Assignment_2.Controllers
{
    public class GiftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiftController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(String orgid)
        {
            TempData["DonationRecipient"] = orgid;
            return View();
        }

        [HttpPost]
        public ActionResult Submit(NFTsDonated donatedNFT)
        {
            donatedNFT.OrgId = TempData["DonationRecipient"].ToString();
            System.Console.WriteLine(donatedNFT.OrgId);
            _context.NFTsDonated.Add(donatedNFT);
            _context.SaveChanges();
            TempData["Result"] = "Thank you donating!";
            ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
