using FluentValidation;

namespace Users.ApplicationCore.Commands
{
    public class CreateUserValidator :AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.LastName).NotEmpty();
        }
    }
}
