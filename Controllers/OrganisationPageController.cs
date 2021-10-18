using FIT5032_Assignment_2.Data;
using FIT5032_Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Controllers
{
    public class OrganisationPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisationPageController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(String orgid)
        {
            OrganisationPage data = FetchData(orgid);
            return View(data);
        }

        private OrganisationPage FetchData(String orgid)
        {
            var org = from od in _context.OrganisationDetails
                         where od.UserId == orgid
                         select new
                         {
                             orgid = od.UserId,
                             project_title = od.Project_Title,
                             org_name = od.Org_Name,
                             org_url = od.Org_URL,
                             target = od.Target_Amount,
                             dateline = od.Dateline
                         };

            var bought = from nb in _context.NFTsBought
                         where nb.OrgId == orgid
                         select new
                         {
                             sold_for = nb.Sold_For
                         };

            var nfts = from nd in _context.NFTsDonated
                       where nd.Bought_Tx == null
                       select new
                       {
                           nft_url = nd.NFT_URL,
                           donor = nd.Donor_Address
                       };


            OrganisationPage orgpage = new OrganisationPage();

            foreach (var item in org)
            {
                orgpage.OrgId = item.orgid;
                orgpage.ProjectTitle = item.project_title;
                orgpage.Organisation = item.org_name;
                orgpage.Organisation_URL = item.org_url;
                orgpage.TargetAmount = item.target;
                orgpage.Dateline = item.dateline;
            }

            float total = 0;
            foreach (var item in bought)
            {
                total += item.sold_for;
            }
            orgpage.AmountFunded = total;

            Dictionary<String, String> nft_url_donor = new Dictionary<String, String>();
            foreach (var item in nfts)
            {
                nft_url_donor.Add(item.nft_url, item.donor);
            }
            orgpage.NFT_URL_Donor = nft_url_donor;

            return orgpage;
        }
    }
}
