using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.SystemEntities
{
    public class Employee : IEntity
    {
        public int EmpoyeeId { get; set; }
        public string? EmpUserName { get; set; }
        public string? EmpPassword { get; set; }
        public string? EmpName { get; set; }
        public string? EmpSurname { get; set; }
        public string? EmpAddress { get; set; }
        public string? EmpEmail { get; set; }
        public DateTime? EmpBirthDate { get; set; }
        public string? EmpPhoneNumber { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
