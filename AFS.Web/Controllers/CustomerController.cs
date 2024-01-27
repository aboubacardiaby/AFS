using AFS.Web.Data.Repos;
using AFS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                lists.Add(new CustomerModel() { Address = item.Address, CustomerId = item.CustId, Name = Name, Phone = item.PhoneNumber });
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
                    LastName = customer.LastName,
                    Region = customer.Region,
                    Email = customer.Email,
                    Genre = customer.Genre,
                    JoinDate = Convert.ToDateTime(customer.JoinDate),
                    Phone = customer.PhoneNumber
                };
#pragma warning restore CS8601 // Possible null reference assignment.
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(string customerid, [Bind("CustomerId,Firstname,LastName, Address, Phone,Genre, Region, joinDate, NationalIdNumber")] CustomerModel model)
        {
            try
            {
                if (model.NationalIdNumber != null)
                {
                    var newcustomer = new Data.Entities.Customer()
                    {
                        CustId = model.NationalIdNumber,
                        FirstName = model.Firstname,
                        Address = model.Address,
                        LastName = model.LastName,
                        Genre = model.Genre,
                        Email = model.Email,
                        City = model.City ?? "BP",
                        Region = model.Region,
                        PhoneNumber = model.Phone,
                        NationalIdNumber = model.NationalIdNumber,
                        JoinDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        CreatedBy = "test1"
                    };
                    await _repository.AddCustomer(newcustomer);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception exec)
            {
                throw;
            }
            return View(new CustomerModel());
        }

        public async Task<IActionResult> Details(string? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }
            var customer = await _repository.GetCustomerDetails(customerId);
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
                LastName = customer.LastName,
                JoinDate = Convert.ToDateTime(customer.JoinDate),
                Email = customer.Email,
                Genre = customer.Genre,
                Region = customer.Region,
                Phone = customer.PhoneNumber
            };
            return View(model);
        }

        public async Task<IActionResult> LoanApp()
        {
            List<SelectListItem> values = new()
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" }
            };
            ViewBag.data = values.ToList();

            List<SelectListItem> regions = new()
            {
                new SelectListItem { Value = "Dakar", Text = "Dakar" },
                new SelectListItem { Value = "Saint louis", Text = "Saint Louis" },
                 new SelectListItem { Value = "Diourbel", Text = "Diourbel" },
                new SelectListItem { Value = "Fatick", Text = "Fatick" },
                 new SelectListItem { Value = "Kolda", Text = "Kolda" },
                new SelectListItem { Value = "Tamba", Text = "Tamba" },
                 new SelectListItem { Value = "Kaolack", Text = "Kaolack" },
                new SelectListItem { Value = "Louga", Text = "Louga" },
                 new SelectListItem { Value = "Sedhiou", Text = "Sedhiou" },
                new SelectListItem { Value = "Matam", Text = "Matam" },
                 new SelectListItem { Value = "Ziguinchor", Text = "Ziguinchor" },
                new SelectListItem { Value = "Thies", Text = "Thies" },
                new SelectListItem { Value = "Kaffrine", Text = "Kaffrine" },
                new SelectListItem { Value = "Kedougou", Text = "Kedougou" }
            };
            ViewBag.regions = regions.ToList();
            return View(new LoanApplicationViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoanApp(string customerid, [Bind("PrimaryOfficer,PreparedBy,FirstName,LastName, Address,Village, Telephone,Departement,Genre, Email,Region, joinDate, NationalIdNumber,CurrentBusiness,BusinessPurpose,Amount,Term")] LoanApplicationViewModel model)
        {
            try
            {
                model.NationalIdNumber = "4511";
                model.Loanstatus = "new";
               
                if (model.NationalIdNumber != null)
                { 
                   
                    await _repository.CreateLoanApplication(model);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception exec)
            {
                throw;
            }
            return View(new CustomerModel());
        }

    }
}