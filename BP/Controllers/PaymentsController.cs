using BP.Data;
using BP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BP.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            var model = new PaymentViewModel();
                return View(model);
        }

        [HttpPost]
        public void TogglePaid(int id)
        {
            using(var context = new BPContext())
            {
                var perf = context.Performances.FirstOrDefault(g => g.ID == id);
                if (perf != null)
                {
                    perf.Paid = !perf.Paid;
                    context.SaveChanges();
                }
                else
                    throw new System.Exception("Could not find performance");
            }
        }
    }
}
