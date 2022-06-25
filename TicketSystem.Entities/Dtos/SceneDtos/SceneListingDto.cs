using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class SceneListingDto : IDto
    {
        public int SceneId { get; set; }
        public string? SceneType { get; set; }
    }
}
