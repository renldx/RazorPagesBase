using FluentValidation;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Commands.UpdateContact;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    private readonly IRPWADbContext context;

    public UpdateContactCommandValidator(IRPWADbContext context)
    {
        this.context = context;

        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(5).MaximumLength(10);

        RuleFor(c => c.LastName).NotEmpty().MinimumLength(5).MaximumLength(10);
    }
}
