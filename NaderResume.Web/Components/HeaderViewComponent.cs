using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Header");
        }

        #endregion
    }
}
