using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPWA.Application.Contacts.Commands.UpdateContact;
using RPWA.Application.Contacts.Queries.GetContact;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class EditModel(IMediator mediator, IMapper mapper) : PageModel
    {
        private readonly IMediator mediator = mediator;
        private readonly IMapper mapper = mapper;

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid || Contact is null)
            {
                return Page();
            }

            var command = new UpdateContactCommand
            {
                Id = id.Value,
                FirstName = Contact.FirstName,
                LastName = Contact.LastName
            };

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
