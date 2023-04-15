using AFS.Web.Data.Repos;
using AFS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            var query = _repository.GetCustomers();
            var lists = new List<CustomerModel>();
            foreach (var item in query)
            {
                lists.Add(new CustomerModel() { Address = item.Address, CustomerId = item.CustId, Firstname = item.FirstName, LastName = item.Name, Phone = item.PhoneNumber });
            }
            return View(lists);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
