using Microsoft.AspNetCore.Mvc;

namespace NaderResume.Web.Components
{
    public class HeaderViewComponent : ViewComponent
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Header");
        }
    }
}
