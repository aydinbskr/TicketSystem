using TicketSystem.Core.Abstract.Entities;

namespace TicketSystem.Entities.Dtos
{
    public class EmployeeUpdateDto : IDto
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
    }
}
