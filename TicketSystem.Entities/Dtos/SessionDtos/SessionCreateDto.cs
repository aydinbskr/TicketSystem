using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SessionCreateDto : IDto
    {
        public int MovieId { get; set; }
        public int SceneId { get; set; }
        public DateTime SessionTime { get; set; }
    }
}
