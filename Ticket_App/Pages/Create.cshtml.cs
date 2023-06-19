using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ticket_App.Data;
using Ticket_App.Models;
using Ticket_App.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace Ticket_App.Pages.Shared.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly Ticket_App.Data.ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public string Name { get; set; }
        public string CardNumber { get; set; }
        public List<TicketTopic> Topics = new List<TicketTopic>();

        public CreateModel(Ticket_App.Data.ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            this._emailSender = emailSender;
        }

        public IActionResult OnGet(string cardNumber)
        {
            var employeeName = _context.Employee
                .Where (a => a.CardNumber == cardNumber)
                .Select(b => b.EmployeeName)
                .FirstOrDefault();

            Name = employeeName;
            CardNumber = cardNumber;

            foreach(var topic in _context.TicketTopic)
            {
                Topics.Add(new TicketTopic(topic.TicketTopicID, topic.TicketTopicName, topic.ImageName));
            }
            

            foreach(var topic in Topics)
            {
                Console.WriteLine(topic.TicketTopicID + " " + topic.TicketTopicName);
            }


            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string cardNumber)
        {
            var employeeName = _context.Employee
                .Where(a => a.CardNumber == cardNumber)
                .Select(b => b.EmployeeName)
                .FirstOrDefault();

            Name = employeeName;
            CardNumber = cardNumber;

            if (!ModelState.IsValid || _context.Ticket == null || Ticket == null)
              {
                  return Page();
              };

            Ticket.CreatedAT = DateTime.Now;

            var receiver = "";
            var subject = this.Ticket.Subject + " " + this.Name;
            var message = "S-a creat o solicitare din parea lui " + this.Name + ", a cerut: " + this.Ticket.Subject
                + System.Environment.NewLine + "Solicitarea s-a creat la data : " + DateTime.Now;

            await _emailSender.SendEmailAsync(receiver, subject, message);

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ThankYou");
        }
    }
}
