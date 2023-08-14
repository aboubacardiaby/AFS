using AFS.Web.Data.Entities;
using AFS.Web.Data.Repos;
using AFS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

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

        public async Task<IActionResult> AddOrEdit(string? customerid)
        {
            ViewBag.PageName = customerid == null ? "Create Customder" : "Edit Customer";
            ViewBag.IsEdit = customerid == null ? false : true;
            if (customerid == null)
            {
                return View();
            }
            else
            {
               var customer = await _repository.GetCustomerById(customerid);

                if (customer == null)
                {
                    return NotFound();
                }
                var model = new CustomerModel()
                {
                    Address = customer.Address,
                    CustomerId = customer.CustId,
                    NationalIdNumber = customer.NationalIdNumber,
                    Firstname = customer.FirstName,
                    LastName = "",
                    Phone = customer.PhoneNumber
                };
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(  string customerid, [Bind("CustomerId,Firstname,Lastname,LastName, Address, Phone,NationalIdNumber")] CustomerModel model)
        {

            model.CustomerId = "new";


            if ( model.NationalIdNumber != null)
            {
                var newcustomer = new Data.Entities.Customer()
                {
                    CustId = model.NationalIdNumber,
                    FirstName = model.Firstname,
                    Address = model.Address,
                    Name = string.Format("{0}, {1}", model.Firstname, model.LastName),
                    PhoneNumber = model.Phone,
                    NationalIdNumber = model.NationalIdNumber,
                    CreatedDate = DateTime.Now,
                    CreateUser= "ab.diaby",
                    UpdateDate = DateTime.Now,
                    UpdateUser = "ab.diaby"

                };
                await _repository.AddCustomer(newcustomer);


                return RedirectToAction(nameof(Index));
            }
            return View(new CustomerModel());
        }

        public async Task<IActionResult> Details(string? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }
            var customer = await  _repository.GetCustomerDetails(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var model = new CustomerModel()
            {
                Address = customer.Address,
                CustomerId = customerId,
                NationalIdNumber = customer.NationalIdNumber,
                Firstname = customer.FirstName,
                LastName = "",
                Phone = customer.PhoneNumber
            };
            return View(model);
        }

    }
}
