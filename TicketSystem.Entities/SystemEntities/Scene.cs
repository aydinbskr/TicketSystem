using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Scene : IEntity
    {
        public int SceneId { get; set; }
        public string? SceneType { get; set; }
        public List<Seat>? Seats { get; set; }
        public List<Session>? Sessions { get; set; }
    }
}
