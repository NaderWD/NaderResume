using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Areas.Admin.Controllers
{
    [Route("/admin/")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
