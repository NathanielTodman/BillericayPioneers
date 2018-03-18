using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BP.Models;
using BP.Data;
using Microsoft.AspNetCore.Authorization;

namespace BP.Controllers
{
    [Authorize(Roles = "Manager")]
    public class HomeController : Controller
    {
        private BPContext _context;

        public HomeController(BPContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            
            return RedirectToAction(nameof(PerformancesController.GetPlayerRankings), "Performances");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
