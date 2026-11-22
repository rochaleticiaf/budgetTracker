using BudgetWebApp.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetWebApp.Business.Data
{
    public class AppDBContext : DbContext
    {
        public IConfiguration _config {  get; set; }
        public AppDBContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }
        public DbSet<tb_type> Tb_type { get; set; }
        public DbSet<tb_category> Tb_category { get; set; }
        public DbSet<tb_expenses> Tb_expenses{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tb_type>()
                .HasOne(t => t.Category)
                .WithMany(c => c.tb_Types)
                .HasForeignKey(t => t.Id_category)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<tb_category>()
                .HasMany(category => category.tb_Types)
                .WithOne(type => type.Category)
                .HasForeignKey(type => type.Id_category)
                .HasPrincipalKey(category => category.Id);

            modelBuilder.Entity<tb_expenses>()
                .HasOne(expense => expense.Type)
                .WithOne(type => type.Expenses)
                .HasForeignKey<tb_expenses>(expense => expense.Id_Type)
                .HasPrincipalKey<tb_type>(type => type.Id)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
