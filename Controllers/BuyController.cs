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
    public class BuyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(String orgid, String link)
        {
            TempData["OwningOrganisation"] = orgid;
            TempData["NFT_URL"] = link;

            return View();
        }

        [HttpPost]
        public ActionResult Submit(NFTsBought boughtNFT)
        {
            boughtNFT.OrgId = TempData["OwningOrganisation"].ToString();
            boughtNFT.NFT_URL = TempData["NFT_URL"].ToString();

            System.Console.WriteLine(boughtNFT.OrgId);
            var cols = _context.NFTsDonated.Where(w => w.NFT_URL == boughtNFT.NFT_URL);
            foreach(var item in cols)
            {
                item.Bought_Tx = boughtNFT.Tx_Hash;
            }
            _context.NFTsBought.Add(boughtNFT);
            _context.SaveChanges();
            TempData["Result"] = "Thank you for buying!";
            //ModelState.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
