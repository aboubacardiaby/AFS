using AFS.Web.Data.Entities;
using AFS.Web.Data.Repos;
using AFS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
                string Name = string.Format("{0}, {1}", item.FirstName, item.LastName);
                lists.Add(new CustomerModel() { Address = item.Address, CustomerId = item.CustId, Name =  Name, Phone = item.PhoneNumber });
            }
            return View(lists);
        }

        public async Task<IActionResult> AddOrEdit(string? customerid)
        {
            List<SelectListItem> values = new()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" }
            };
            ViewBag.data = values.ToList();

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
#pragma warning disable CS8601 // Possible null reference assignment.
                var model = new CustomerModel()
                {
                    Address = customer.Address,
                    CustomerId = customer.CustId,
                    NationalIdNumber = customer.NationalIdNumber,
                    Firstname = customer.FirstName,
                    LastName = "",
                    Phone = customer.PhoneNumber
                };
#pragma warning restore CS8601 // Possible null reference assignment.
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(  string customerid, [Bind("CustomerId,Firstname,LastName, Address, Phone,Genre, Region, joinDate, NationalIdNumber")] CustomerModel model)
        {

           


            if ( model.NationalIdNumber != null)
            {
                var newcustomer = new Data.Entities.Customer()
                {
                    CustId = model.NationalIdNumber,
                    FirstName = model.Firstname,
                    Address = model.Address,
                    LastName = model.LastName,
                    Genre = model.Genre,
                    Email = model.Email,
                    Region = model.Region,                 
                    PhoneNumber = model.Phone,
                    NationalIdNumber = model.NationalIdNumber,
                    JoinDate = DateTime.Now,
                    

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
