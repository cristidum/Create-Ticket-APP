using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticket_App.Models;

namespace Ticket_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<Ticket_App.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<Ticket_App.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Ticket_App.Models.TicketTopic> TicketTopic { get; set; } = default!;
    }
}