using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Areas.Admin.Components
{
    [ViewComponent]
    public class LeftSideBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LeftSideBar");
        }

    }
}
