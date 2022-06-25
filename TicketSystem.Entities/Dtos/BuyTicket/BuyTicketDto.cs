using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class BuyTicketDto : IDto
    {
        public int SeatNumber { get; set; }
        public int SessionId { get; set; }
        public int Price { get; set; }
    }
}
