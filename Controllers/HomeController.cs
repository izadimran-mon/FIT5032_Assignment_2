using FIT5032_Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FIT5032_Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        List<DataGrid> data = new List<DataGrid>();

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                FetchData();
                ViewData["SubmitInfoStatus"] = QueryStatus();
                return View(data);
            }
            else
            {
                return View();
            }

        }

        private String QueryStatus()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var found = from u in _context.OrganisationDetails
                        where u.UserId == userid
                        select new
                        {
                            orgid = u.UserId
                        };

            return found.Any() ? "true" : "false";
        }

        private void FetchData()
        {
            var orgs = from od in _context.OrganisationDetails
                       select new
                       {
                           orgid = od.UserId,
                           project_title = od.Project_Title,
                           org_url = od.Org_URL,
                           org_name = od.Org_Name,
                           target = od.Target_Amount,
                           dateline = od.Dateline
                       };

            Dictionary<String, float> amountRaised = new Dictionary<string, float>();

            foreach (var org in orgs)
            {
                amountRaised.Add(org.orgid, 0);
                var nftsold = from n in _context.NFTsBought
                              where n.OrgId == org.orgid
                             select new
                             {
                                 orgid = n.OrgId,
                                 soldfor = n.Sold_For
                             };

                if (nftsold.Any())
                {
                    foreach (var row in nftsold)
                    {
                        amountRaised[org.orgid] += row.soldfor;
                    }
                    System.Console.WriteLine(amountRaised[org.orgid]);
                }
                data.Add(new DataGrid()
                {
                    OrgId = org.orgid,
                    ProjectTitle = org.project_title,
                    Organisation = org.org_name,
                    Organisation_URL = org.org_url,
                    AmountFunded = amountRaised[org.orgid],
                    TargetAmount = org.target
                });

            } 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
