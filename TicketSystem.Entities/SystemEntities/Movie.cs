using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Movie : IEntity
    {
        public int MovieId { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public string? MovieName { get; set; }
        public DateTime MovieVisionDate { get; set; }
        public byte[]? MovieBanner { get; set; }
        public int MovieCategoryId { get; set; }
        public Category? Category { get; set; }
        public int? MovieIMDB { get; set; }
        public string? MovieReview { get; set; }
        public int? MovieAgeLimit { get; set; }
        public List<Session>? Sessions { get; set; }
    }
}
