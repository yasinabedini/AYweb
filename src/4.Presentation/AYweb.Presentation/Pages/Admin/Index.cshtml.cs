using AYweb.Presentation.Atteribute.PermissionChacker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AYweb.Presentation.Pages.Admin
{
    [PermissionChecker(1110)]
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
