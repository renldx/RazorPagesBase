using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPWA.Application.Contacts.Queries.GetContacts;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class IndexModel(IMediator mediator, IMapper mapper) : PageModel
    {
        private readonly IMediator mediator = mediator;
        private readonly IMapper mapper = mapper;

        public IList<ContactBriefVm> Contacts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var query = new GetContactsQuery();
            var contacts = await mediator.Send(query);

            if (contacts is not null)
            {
                Contacts = mapper.Map<List<ContactBriefVm>>(contacts);
            }
        }

        public class ContactBriefVm
        {
            public int Id { get; init; }

            public string Sin { get; init; } = default!;

            public string Name => $"{FirstName} {LastName}";

            public string FirstName { get; init; } = default!;

            public string LastName { get; init; } = default!;

            private class Mapping : Profile
            {
                public Mapping()
                {
                    CreateMap<ContactBriefDto, ContactBriefVm>();
                }
            }
        }
    }
}
