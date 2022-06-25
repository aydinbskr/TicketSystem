using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SessionListingDto : IDto
    {
        public int SessionId { get; set; }
        public int MovieId { get; set; }
        public int SceneId { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
