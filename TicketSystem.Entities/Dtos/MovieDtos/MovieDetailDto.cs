using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos.MovieDtos
{
    public class MovieDetailDto : IDto
    {
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public DateTime MovieVisionDate { get; set; }
        public byte[]? MovieBanner { get; set; }
        public string? CategoryName { get; set; }
        public int? MovieIMDB { get; set; }
        public string? MovieReview { get; set; }
        public int? MovieAgeLimit { get; set; }
    }
}
