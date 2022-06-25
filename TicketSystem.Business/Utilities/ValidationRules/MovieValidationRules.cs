using FluentValidation;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Utilities.ValidationRules
{
    public class MovieValidationRules : AbstractValidator<Movie>
    {
        public MovieValidationRules()
        {
            RuleFor(m => m.EmployeeId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(m => m.MovieCategoryId).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(m => m.MovieName).NotEmpty();
            RuleFor(m => m.MovieVisionDate).NotEmpty().NotNull();
            RuleFor(m => m.MovieBanner).NotEmpty().NotNull();
            RuleFor(m => m.MovieAgeLimit).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
