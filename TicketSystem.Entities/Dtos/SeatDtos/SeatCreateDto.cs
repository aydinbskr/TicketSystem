using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SeatCreateDto : IDto
    {
        public int SceneId { get; set; }
        public int SeatNumber { get; set; }
        public int SessionId { get; set; }
    }
}
