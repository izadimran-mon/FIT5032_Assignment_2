using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using FIT5032_Assignment_2.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FIT5032_Assignment_2.Controllers
{
    public class PublishController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const String API_KEY = "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";

        public PublishController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            if (files.Length > 0)
            {
                var emails = from u in _context.Users
                             join ur in _context.UserRoles on u.Id equals ur.UserId
                             join r in _context.Roles on ur.RoleId equals r.Id
                             where r.Name == "Donor/Buyer"
                             select new
                             {
                                 email = u.Email
                             };
                var client = new SendGridClient(API_KEY);
                var from = new EmailAddress("izadimrang7@gmail.com", "NFTsForGood");
                var plainTextContent = "";
                var htmlContent = "<p>Newsletter</p>";

                String content = "";
                var fileName = Path.GetFileName(files.FileName);
                var fileExtension = Path.GetExtension(fileName);
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                var objFiles = new Files()
                {
                    DocumentId = 0,
                    Name = newFileName,
                    FileType = fileExtension,
                    CreatedOn = DateTime.Now
                };
                using (var target = new MemoryStream())
                {
                    files.CopyTo(target);
                    var fileBytes = target.ToArray();
                    objFiles.DataFiles = fileBytes;
                    content = Convert.ToBase64String(fileBytes);
                }

                _context.Files.Add(objFiles);
                _context.SaveChanges();

                foreach (var e in emails)
                {
                    //System.Console.WriteLine(e.email);
                    var to = new EmailAddress(e.email, "");
                    var msg = MailHelper.CreateSingleEmail(from, to, "NFT Newsletter", plainTextContent, htmlContent);
                    msg.AddAttachment("Newsletter File", content);
                    var response = client.SendEmailAsync(msg);
                    TempData["Result"] = "Your newsletter have been sent to our subscribers.";
                    //System.Console.WriteLine(response.Result.StatusCode);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
