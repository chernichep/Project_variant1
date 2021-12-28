using Microsoft.EntityFrameworkCore;
using Project.Model;

namespace Project.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Aggrement> Aggrements { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\LocalDB; Database = ProjectDatabase; Trusted_Connection = true;");

        }
    }
}
