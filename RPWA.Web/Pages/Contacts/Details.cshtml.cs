using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPWA.Application.Contacts.Queries.GetContact;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class DetailsModel(IMediator mediator, IMapper mapper) : PageModel
    {
        private readonly IMediator mediator = mediator;
        private readonly IMapper mapper = mapper;

        public ContactVm Contact = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var query = new GetContactQuery(id.Value);
            var contact = await mediator.Send(query);

            if (contact is null)
            {
                return NotFound();
            }
            else
            {
                Contact = mapper.Map<ContactVm>(contact);
            }
            return Page();
        }

        public class ContactVm
        {
            public int Id { get; init; }

            public string Sin { get; init; } = null!;

            public string Name => $"{FirstName} {LastName}";

            public string FirstName { get; init; } = null!;

            public string LastName { get; init; } = null!;

            public DateTime DateOfBirth { get; init; }

            public decimal YearlyIncome { get; init; }

            public string PhoneNumber { get; init; } = null!;

            public string Email { get; init; } = null!;

            public string Website { get; init; } = null!;

            public bool IsFavorite { get; init; }

            private class Mapping : Profile
            {
                public Mapping()
                {
                    CreateMap<ContactDto, ContactVm>();
                }
            }
        }
    }
}
