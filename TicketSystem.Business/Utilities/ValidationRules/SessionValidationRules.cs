using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class SessionValidationRules : AbstractValidator<Session>
    {
        public SessionValidationRules()
        {
            RuleFor(s => s.SessionTime).NotEmpty().NotNull();
            RuleFor(s => s.MovieId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(s => s.SceneId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
