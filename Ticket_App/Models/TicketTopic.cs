namespace Ticket_App.Models
{
    public class TicketTopic
    {
        public TicketTopic(int ticketTopicID, string ticketTopicName, string imageName)
        {
            TicketTopicID = ticketTopicID;
            TicketTopicName = ticketTopicName;
            ImageName = imageName;
        }

        public int TicketTopicID { get; set; }
        public string TicketTopicName { get; set; }
        public string ImageName { get; set; }

    }
}
