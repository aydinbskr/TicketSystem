using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class MovieCreateDto : IDto
    {
        public int EmployeeId { get; set; }
        public string? MovieName { get; set; }
        public DateTime MovieVisionDate { get; set; }
        public DateTime MovieReleaseTime { get; set; }
        public byte[]? MovieBanner { get; set; }
        public int MovieCategoryId { get; set; }
        public int? MovieIMDB { get; set; }
        public string? MovieReview { get; set; }
        public int? MovieAgeLimit { get; set; }
    }
}
