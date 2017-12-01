using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BP.Models;
using BP.Data;

namespace BP.Controllers
{
    public class HomeController : Controller
    {
        private BPContext _context;

        public HomeController(BPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PerformancesController.GetPlayerRankings), "Performances");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
