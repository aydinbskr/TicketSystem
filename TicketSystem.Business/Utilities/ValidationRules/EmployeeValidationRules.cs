using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class EmployeeValidationRules : AbstractValidator<Employee>
    {
        public EmployeeValidationRules()
        {
            RuleFor(e => e.EmpUserName).NotEmpty().NotNull();
            RuleFor(e => e.EmpPassword).NotEmpty().NotNull();
            RuleFor(e => e.EmpName).NotEmpty().NotNull();
            RuleFor(e => e.EmpSurname).NotEmpty().NotNull();
            RuleFor(e => e.EmpEmail).NotEmpty().NotNull();
            RuleFor(e => e.EmpPhoneNumber).NotEmpty().NotNull();
        }
    }
}
