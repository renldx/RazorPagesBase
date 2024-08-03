using MediatR;
using RPWA.Application.Common.Interfaces;
using RPWA.Domain.Entities;

namespace RPWA.Application.Contacts.Commands.CreateContact;

public record CreateContactCommand : IRequest<int>
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IRPWADbContext context;

    public CreateContactCommandHandler(IRPWADbContext context)
    {
        this.context = context;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new Contact { FirstName = request.FirstName, LastName = request.LastName };

        context.Contact.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
