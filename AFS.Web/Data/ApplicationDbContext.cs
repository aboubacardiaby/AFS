using AFS.Web.Data.Entities;
using AFS.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AFS.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
              
        }
      
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblLoan { get; set; }
        public DbSet<Payment> tblPayment { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
