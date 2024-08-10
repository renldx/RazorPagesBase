using AutoMapper;
using RPWA.Domain.Entities;
using RPWA.Domain.Enums;

namespace RPWA.Application.Contacts.Queries.GetContact;

public class ContactDto
{
    public int Id { get; init; }

    public string Sin { get; init; } = default!;

    public string Name => $"{FirstName} {LastName}";

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public DateTime DateOfBirth { get; init; }

    public Gender? Gender { get; init; }

    public decimal? YearlyIncome { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Email { get; init; }

    public string? Website { get; init; }

    public bool IsFavorite { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateProjection<Contact, ContactDto>();
        }
    }
}
