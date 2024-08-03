using AutoMapper;
using RPWA.Domain.Entities;
using RPWA.Domain.Enums;

namespace RPWA.Application.Contacts.Queries.GetContacts;

public class ContactDto
{
    public int Id { get; set; }

    public string Sin { get; set; } = null!;

    public string Name => $"{FirstName} {LastName}";

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }

    public decimal YearlyIncome { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Website { get; set; } = null!;

    public bool IsFavorite { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ContactDto>();
        }
    }
}
