using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class TicketValidationRules : AbstractValidator<Ticket>
    {
        public TicketValidationRules()
        {
            RuleFor(t => t.CustomerId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
            RuleFor(t => t.SessionId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
            RuleFor(t => t.Price).NotNull().GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(t => t.SeatId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);

        }
    }
}
