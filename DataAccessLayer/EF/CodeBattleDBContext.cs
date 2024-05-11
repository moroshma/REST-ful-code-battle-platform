using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.EF
{
    public class CodeBattleDBContext : DbContext
    {
        public CodeBattleDBContext(DbContextOptions<CodeBattleDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Database=postgres", b => b.MigrationsAssembly("PresentationLayer"));
            }
        }
    }
}
