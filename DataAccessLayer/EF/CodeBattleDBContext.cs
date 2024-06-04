using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using  Npgsql.EntityFrameworkCore.PostgreSQL;
using DataAccessLayer.Models;
using Task = DataAccessLayer.Models.Task;


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
        public DbSet<Level> Level { get; set; }
        public DbSet<Battle> Battle { get; set; }
        public DbSet<Solution> Solution { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TestCase> TestCase { get; set; }
        public DbSet<UserBattle> UserBattle { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBattle>()
                .HasKey(bg => new { bg.UserID, bg.BattleID });

            modelBuilder.Entity<UserBattle>()
                .HasOne(bg => bg.User)
                .WithMany(b => b.UserBattle)
                .HasForeignKey(bg => bg.UserID);

            modelBuilder.Entity<UserBattle>()
                .HasOne(bg => bg.Battle)
                .WithMany(g => g.UserBattle)
                .HasForeignKey(bg => bg.BattleID);
        }
    }
}
