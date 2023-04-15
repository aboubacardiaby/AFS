using AFS.Web.Data.Entities;

namespace AFS.Web.Data.Repos
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.tblCustomer.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.tblCustomer.ToList();
        }
    }
}
