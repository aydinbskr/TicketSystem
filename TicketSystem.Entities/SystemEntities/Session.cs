using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Session : IEntity
    {
        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int SceneId { get; set; }
        public Scene? Scene { get; set; }
        public DateTime SessionTime { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
