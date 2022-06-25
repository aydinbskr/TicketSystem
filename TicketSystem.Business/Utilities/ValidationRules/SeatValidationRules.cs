using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class SeatValidationRules : AbstractValidator<Seat>
    {
        public SeatValidationRules()
        {
            RuleFor(s => s.SceneId).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
            RuleFor(s => s.SeatNumber).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(s => s.SessionId).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
