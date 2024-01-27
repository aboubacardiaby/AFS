using AFS.Web.Data.Entities;
using AFS.Web.Models;

namespace AFS.Web.Data.Repos
{
    public interface IRepository
    {
         Task  AddCustomer(Customer customer);

        Task CreateLoanApplication(LoanApplicationViewModel customer);
        Task<Customer> GetCustomerById(string id);
        // Task<Customer> GetCustomerDa

        Task<Customer> GetCustomerDetails(string customerid);
         List<Customer> GetCustomers();

       Task<Loan> GetLoanInfobyCustomerAsync(string customerid);
        
    }
}