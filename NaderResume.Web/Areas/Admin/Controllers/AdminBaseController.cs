using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class AdminBaseController : Controller
    {
        protected string SuccessMessage = "SuccessMessage";
        protected string ErrorMessage = "ErrorMessage";
    }
}
