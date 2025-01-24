using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Areas.Admin.Components
{
    public class LeftSideBarViewComponent : ViewComponent
    {

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_LeftSideBar");
        }

        #endregion

    }
}
