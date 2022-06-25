using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class TicketListingDto : IDto
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int SeatId { get; set; }
    }
}
