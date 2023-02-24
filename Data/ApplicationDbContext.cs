using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using test4.Models;

namespace test4.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ANONYMOUS\\SQLEXPRESS;Initial Catalog=Test_Invoice2;Integrated Security=True;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var e in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var fk in e.GetForeignKeys())
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;
        public virtual DbSet<Invoice> Invoice { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; } = null!;



    }
}
