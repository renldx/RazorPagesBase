using MediatR;
using Microsoft.EntityFrameworkCore;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Commands.DeleteContact;

public record DeleteContactCommand(int Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IRPWADbContext context;

    public DeleteContactCommandHandler(IRPWADbContext context)
    {
        this.context = context;
    }

    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        await context.Contacts.Where(c => c.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
    }
}
