using MediatR;
using Microsoft.EntityFrameworkCore;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Commands.UpdateContact;

public record UpdateContactCommand : IRequest
{
    public int Id { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;
}

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IRPWADbContext context;

    public UpdateContactCommandHandler(IRPWADbContext context)
    {
        this.context = context;
    }

    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        await context
            .Contacts.Where(c => c.Id == request.Id)
            .ExecuteUpdateAsync(
                setters =>
                    setters
                        .SetProperty(c => c.FirstName, request.FirstName)
                        .SetProperty(c => c.LastName, request.LastName),
                cancellationToken
            );
    }
}
