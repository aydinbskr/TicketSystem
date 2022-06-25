using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class TicketCreateDto : IDto
    {
        public int SessionId { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int SeatId { get; set; }
    }
}
