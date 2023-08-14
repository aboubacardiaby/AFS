using AFS.Web.Data.Entities;
using AFS.Web.Migrations;
using AFS.Web.Models;
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
            bool IsCustomerExist = false;

            Customer customerfromDb = await _context.tblCustomer.FindAsync(customer.CustId);

            if (customerfromDb != null)
            {
                IsCustomerExist = true;
            }
            else
            {
                customerfromDb = new Customer();
            }

            try
            {
               

                if (IsCustomerExist)
                {
                    _context.tblCustomer.Update(customerfromDb);
                }
                else
                {
                  await   _context.tblCustomer.AddAsync(customer);
                }
                await _context.SaveChangesAsync();
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
            return _context.tblCustomer.ToList();
        }
        #region Loan Repos
        public async Task<Loan> GetLoanInfobyCustomerAsync(string customerid)
        {
            return _context.tblCustomer.
        }
        #region
    }
}
