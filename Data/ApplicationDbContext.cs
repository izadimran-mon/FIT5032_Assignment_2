using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using FIT5032_Assignment_2.Models;

namespace FIT5032_Assignment_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Files> Files { get; set; }
        public DbSet<OrganisationDetails> OrganisationDetails { get; set; }
        public DbSet<NFTsBought> NFTsBought { get; set; }
    }
}
