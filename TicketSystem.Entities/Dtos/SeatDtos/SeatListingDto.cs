using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SeatListingDto : IDto
    {
        public int SeatId { get; set; }
        public int SceneId { get; set; }
        public int SeatNumber { get; set; }
        public int SessionId { get; set; }
    }
}
