using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Models;
using FIT5032_Assignment_2.Data;

namespace FIT5032_Assignment_2.Controllers
{
    public class OrganisationDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisationDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(OrganisationDetails model)
        {
            System.Console.WriteLine("lol");
            if (ModelState.IsValid)
            {
                try
                {
                    String org_url = model.Org_URL;
                    String org_name = model.Org_Name;
                    String project_title = model.Project_Title;
                    String description = model.Description;
                    int target_amount = model.Target_Amount;
                    DateTime dateline = model.Dateline;

                    //_context.Organisation_Details.Add(model)
                    ViewBag.Result = "Details have been submitted and project is now up for fund raising!";


                    ModelState.Clear();


                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}
