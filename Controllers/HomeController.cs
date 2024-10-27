using Microsoft.AspNetCore.Mvc;
using MVCEmp.Models;
using System.Diagnostics;

namespace MVCEmp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            var errorModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(errorModel);
        }
    }
}
