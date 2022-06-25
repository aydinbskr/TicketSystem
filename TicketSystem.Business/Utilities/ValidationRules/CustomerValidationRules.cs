using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class CustomerValidationRules : AbstractValidator<Customer>
    {
        public CustomerValidationRules()
        {
            RuleFor(c => c.Username).NotEmpty().NotNull();
            RuleFor(c => c.Password).NotEmpty().NotNull().Length(5, 16);
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Surname).NotEmpty().NotNull();
            RuleFor(c => c.Email).NotEmpty().NotNull();
        }
    }
}
