using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationLM.Models;

namespace WebApplicationLM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplicationLM.Models.Card> Card { get; set; }
        public DbSet<WebApplicationLM.Models.Column> Column { get; set; }
        public DbSet<WebApplicationLM.Models.Workspace> Workspace { get; set; }
    }
}
