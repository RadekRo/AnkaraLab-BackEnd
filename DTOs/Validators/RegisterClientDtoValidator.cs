using AnkaraLab_BackEnd.WebAPI.Infrastructure;
using FluentValidation;

namespace AnkaraLab_BackEnd.WebAPI.DTOs.Validators
{
    public class RegisterClientDtoValidator : AbstractValidator<ClientForRegistrationDto>
    {
        public RegisterClientDtoValidator(AnkaraLabDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(1);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Clients.Any(c => c.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is allready taken");
                    }
                });
        }
    }
}

