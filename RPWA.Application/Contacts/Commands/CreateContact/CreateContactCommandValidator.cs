using FluentValidation;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Commands.CreateContact;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    private readonly IRPWADbContext context;

    public CreateContactCommandValidator(IRPWADbContext context)
    {
        this.context = context;

        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(5).MaximumLength(10);

        RuleFor(c => c.LastName).NotEmpty().MinimumLength(5).MaximumLength(10);
    }
}
