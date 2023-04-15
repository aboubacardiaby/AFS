using AFS.Web.Data.Entities;

namespace AFS.Web.Data.Repos
{
    public interface IRepository
    {
        public void AddCustomer(Customer customer);


        public List<Customer> GetCustomers();
        
    }
}