using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos.SessionDtos
{
    public class SessionDetailDto : IDto
    {
        public int SessionId { get; set; }
        public DateTime SessionTime { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int SceneId { get; set; }
        public string SceneType { get; set; }
    }
}
