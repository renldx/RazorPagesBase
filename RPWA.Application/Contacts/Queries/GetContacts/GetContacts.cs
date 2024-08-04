using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RPWA.Application.Common.Interfaces;

namespace RPWA.Application.Contacts.Queries.GetContacts;

public record GetContactsQuery : IRequest<List<ContactBriefDto>>;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactBriefDto>>
{
    private readonly IRPWADbContext context;
    private readonly IMapper mapper;

    public GetContactsQueryHandler(IRPWADbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<List<ContactBriefDto>> Handle(
        GetContactsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await context
            .Contacts.AsNoTracking()
            .ProjectTo<ContactBriefDto>(mapper.ConfigurationProvider)
            .OrderBy(c => c.Id)
            .ToListAsync(cancellationToken);
    }
}
