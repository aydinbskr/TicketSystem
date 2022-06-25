using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SceneUpdateDto : IDto
    {
        public int SceneId { get; set; }
        public string? SceneType { get; set; }
    }
}
