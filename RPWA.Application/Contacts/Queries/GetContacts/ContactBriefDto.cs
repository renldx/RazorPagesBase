using AutoMapper;
using RPWA.Domain.Entities;

namespace RPWA.Application.Contacts.Queries.GetContacts;

public class ContactBriefDto
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
            CreateProjection<Contact, ContactBriefDto>();
        }
    }
}
