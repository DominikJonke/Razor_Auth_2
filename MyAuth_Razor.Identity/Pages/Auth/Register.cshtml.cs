using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAuth_Razor.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuth_Razor.Identity.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public AuthUser AuthUser { get; set; }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByNameAsync(AuthUser.Email);

            if(user != null)
            {
                ModelState.AddModelError(string.Empty, "Register not succeeded!");

                return Page();
            }

            var creatResult = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = AuthUser.Email,
                Email = AuthUser.Password
            }, AuthUser.Password);

            if (!creatResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty,
                    string.Join(
                        ", ", 
                        creatResult.Errors.Select(e => e.Description)));
                
                return Page();
            }

            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
