using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using  Npgsql.EntityFrameworkCore.PostgreSQL;
using DataAccessLayer.Models;


namespace DataAccessLayer.EF
{
    public class CodeBattleDBContext : DbContext
    {
        
        private readonly bool isMigration = false;
       public CodeBattleDBContext()
        {
            isMigration = true;
        }
        public CodeBattleDBContext(DbContextOptions<CodeBattleDBContext> options): base(options)
        {
            Database.EnsureCreated();
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Database=postgres;Port=5432;Password=root;", b => b.MigrationsAssembly("PresentationLayer"));
            }
            if ( isMigration )
            {
                optionsBuilder.UseNpgsql( "Server=localhost;Username=postgres;Database=postgres;Port=5432;Password=root;" );
            }
        }
    }
}
