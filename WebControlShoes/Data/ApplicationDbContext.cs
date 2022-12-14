using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebControlShoes.Areas.Users.Models;
using WebControlShoes.Models;

namespace WebControlShoes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TUsers> TUsers { get; set;}

        public DbSet<Colours> Colours { get; set; }
    }
}
