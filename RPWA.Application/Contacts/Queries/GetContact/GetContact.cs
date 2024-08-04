using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Queries.GetContact;

public record GetContactQuery(int Id) : IRequest<ContactDto?>;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto?>
{
    private readonly IRPWADbContext context;
    private readonly IMapper mapper;

    public GetContactQueryHandler(IRPWADbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<ContactDto?> Handle(
        GetContactQuery request,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Contacts.AsNoTracking()
            .Where(c => c.Id == request.Id)
            .ProjectTo<ContactDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
