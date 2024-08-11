using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPWA.Application.Contacts.Commands.CreateContact;

namespace RazorPagesWebApp.Pages.Contacts
{
    public class CreateModel(IMediator mediator) : PageModel
    {
        private readonly IMediator mediator = mediator;

        [BindProperty]
        public ContactVm Contact { get; set; } = default!;

        public void OnGet() { }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Contact is null)
            {
                return Page();
            }

            var command = new CreateContactCommand
            {
                Sin = Contact.Sin,
                FirstName = Contact.FirstName,
                LastName = Contact.LastName,
                DateOfBirth = Contact.DateOfBirth
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
        }
    }
}
