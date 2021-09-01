using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesCG.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace RazorPagesCG.Data
{
    public class RazorPagesCGContext : IdentityDbContext
    {
        public RazorPagesCGContext (DbContextOptions<RazorPagesCGContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesCG.Models.Character> Character { get; set; }
    }
}
