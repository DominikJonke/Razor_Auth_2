using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAuth_Razor.Identity.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminSettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
