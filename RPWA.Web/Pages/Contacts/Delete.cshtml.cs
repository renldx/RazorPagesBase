using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPWA.Application.Contacts.Commands.DeleteContact;
using RPWA.Application.Contacts.Queries.GetContact;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class DeleteModel(IMediator mediator, IMapper mapper) : PageModel
    {
        private readonly IMediator mediator = mediator;
        private readonly IMapper mapper = mapper;

        public ContactVm Contact { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var command = new DeleteContactCommand(id.Value);

            try
            {
                await mediator.Send(command);
            }
            catch
            {
                throw;
            }

            return RedirectToPage("./Index");
        }

        public class ContactVm
        {
            public string Sin { get; init; } = default!;

            public string FirstName { get; init; } = default!;

            public string LastName { get; init; } = default!;

            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; init; }

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
