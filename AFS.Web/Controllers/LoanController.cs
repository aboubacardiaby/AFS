using Microsoft.AspNetCore.Mvc;

namespace AFS.Web.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index(string? customerId)
        {

            return View();
        }
    }
}
