using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ticket_App.Pages
{
    public class ThankYouModel : PageModel
    {
        public void OnGet()
        {
            Response.Headers.Add("Refresh", "5;/Index");
        }
    }
}
