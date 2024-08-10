using AutoMapper;
using RPWA.Domain.Entities;
using RPWA.Domain.Enums;

namespace RPWA.Application.Contacts.Queries.GetContact;

public class ContactDto
{
    public int Id { get; init; }

    public string Sin { get; init; } = null!;

    public string Name => $"{FirstName} {LastName}";

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public DateTime DateOfBirth { get; init; }

    public Gender Gender { get; init; }

    public decimal YearlyIncome { get; init; }

    public string PhoneNumber { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string Website { get; init; } = null!;

    public bool IsFavorite { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateProjection<Contact, ContactDto>();
        }
    }
}
