using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPWA.Application.Contacts.Commands.CreateContact;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class CreateModel(IMediator mediator, IMapper mapper) : PageModel
    {
        private readonly IMediator mediator = mediator;
        private readonly IMapper mapper = mapper;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactVm Contact { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //ModelState.Remove("Product.ImageName");

            if (!ModelState.IsValid || Contact is null)
            {
                return Page();
            }

            var command = new CreateContactCommand
            {
                FirstName = Contact.FirstName,
                LastName = Contact.LastName
            };

            var contactId = await mediator.Send(command);

            return RedirectToPage("./Index");
        }

        public class ContactVm
        {
            public string FirstName { get; init; } = null!;

            public string LastName { get; init; } = null!;
        }
    }
}
