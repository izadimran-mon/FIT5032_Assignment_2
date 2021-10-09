using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using FIT5032_Assignment_2.Models;

namespace FIT5032_Assignment_2.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisationController(ApplicationDbContext context)
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
                using (var target=new MemoryStream())
                {
                    files.CopyTo(target);
                    objFiles.DataFiles = target.ToArray();
                }

                _context.Files.Add(objFiles);
                _context.SaveChanges();
            }

            return View();
        }
    }
}
