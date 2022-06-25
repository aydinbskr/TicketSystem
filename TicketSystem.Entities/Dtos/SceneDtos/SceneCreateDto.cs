using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SceneCreateDto : IDto
    {
        public string? SceneType { get; set; }
    }
}
