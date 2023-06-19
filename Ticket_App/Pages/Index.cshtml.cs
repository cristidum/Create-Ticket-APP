using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ticket_App.Models;

namespace Ticket_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Ticket_App.Data.ApplicationDbContext _context;

        public IndexModel(Ticket_App.Data.ApplicationDbContext context)
        {
            _context = context;
            
        }

        public void OnGet()
        {

        }
        
        public IActionResult OnPostSubmit(Employee employee)
        {

            int cardNumberCheck = 0;

            cardNumberCheck = _context.Employee
                .Where(a => a.CardNumber == employee.CardNumber)
                .Select(b => b.EmployeeId)
                .FirstOrDefault();

            

            if (employee.CardNumber == null)
            {
                ModelState.AddModelError("InvalidCardNumber", "Va rugam introduceti seria cardului");
                return Page();
            }
            else if (cardNumberCheck == 0)
            {
                ModelState.AddModelError("InvalidCardNumber", "Nu exista cardul cu seria asta");
                return Page();
            }
            else
            {
                return RedirectToPage("/Create", new {cardNumber = employee.CardNumber});
            }
          
        }
        
    }
}