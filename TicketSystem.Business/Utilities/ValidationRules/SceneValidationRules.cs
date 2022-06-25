using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class SceneValidationRules : AbstractValidator<Scene>
    {
        public SceneValidationRules()
        {
            RuleFor(s => s.SceneType).NotEmpty().NotNull();
        }
    }
}
