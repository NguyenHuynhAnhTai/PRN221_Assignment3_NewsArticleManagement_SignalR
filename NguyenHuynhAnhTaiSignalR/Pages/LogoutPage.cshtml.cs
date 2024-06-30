using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NguyenHuynhAnhTaiSignalR.Pages
{
    public class LogoutPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();

            return RedirectToPage("/LoginPage");
        }
    }
}
