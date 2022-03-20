using FluentValidation;
namespace UserIdentityUI.Models
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(8);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(8);
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Gender).NotEmpty().MinimumLength(4).MaximumLength(5);
            RuleFor(x => x.Age).NotEmpty().InclusiveBetween(15, 50);
            RuleFor(x => x.BirthPlace).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Town).NotEmpty();

        }
    }
}
