using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Seat : IEntity
    {
        public int SeatId { get; set; }
        public int SceneId { get; set; }
        public Scene? Scene { get; set; }
        public int SeatNumber { get; set; }
        public int SessionId { get; set; }
    }
}
