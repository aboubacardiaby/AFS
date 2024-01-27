using AFS.Web.Data.Entities;
using AFS.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AFS.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
              .HasOne<Customer>(s => s.Customer)
              .WithMany(g => g.Loans)
              .HasForeignKey(s => s.CustId);

            modelBuilder.Entity<LoanApplication>()
              .HasOne<Customer>(s => s.Customer)
              .WithMany(g => g.LoanApplications)
              .HasForeignKey(s => s.CustId);

            //modelBuilder.Entity<Payment>()
            //.HasOne<Loan>(s => s.loan)
            //.WithMany(g => g.Payments)
            //.HasForeignKey(s => s.LoanNumber);


        }
        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblLoan { get; set; }
        public DbSet<Payment> tblPayment { get; set; }
        public virtual DbSet<Employee> Tblemployee { get; set; }

        public virtual DbSet<LoanApplication> TblLoanApplication { get; set; }
    }
}