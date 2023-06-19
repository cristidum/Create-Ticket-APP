using System.Diagnostics.CodeAnalysis;

namespace Ticket_App.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        [AllowNull] public string CardNumber { get; set; }
        [AllowNull] public string EmployeeName { get; set; }
        [AllowNull] public string Subject { get; set; }
        public DateTime CreatedAT { get; set; }
    }
}
