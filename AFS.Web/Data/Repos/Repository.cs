using AFS.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFS.Web.Data.Repos
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddCustomer(Customer customer)
        {
            try
            {
                await _context.Database
                                       .ExecuteSqlInterpolatedAsync(
                                        $"Usp_AddOrEditCustomer  @CustId ={customer.CustId}, @FirstName ={customer.FirstName}, @LastName ={customer.LastName}, @Genre= {customer.Genre},@Email ={customer.Email}, @PhoneNumber = {customer.PhoneNumber},@Address = {customer.Address},@Region ={customer.Region},@City={customer.City},  @NationalIdNumber = {customer.NationalIdNumber}, @JoinDate={customer.JoinDate}");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<Customer> GetCustomerById(string customerid)
        {
            var customer = await _context.tblCustomer.FindAsync(customerid);
            return customer;
        }

        public async Task<Customer> GetCustomerDetails(string customerid)
        {
            var customer = await _context.tblCustomer.FirstOrDefaultAsync(m => m.CustId == customerid);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            //var customers = _context?.tblCustomer?
            //                        .FromSqlRaw<Customer>($"Usp_GetAllCustomer").ToList();
            return _context.tblCustomer.ToList();
        }

        #region Loan Repos

        public async Task<Loan> GetLoanInfobyCustomerAsync(string customerid)
        {
            return null;
            //return _context.tblCustomer.
        }

        #endregion Loan Repos
    }
}