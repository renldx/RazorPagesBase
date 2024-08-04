using AutoMapper;
using RPWA.Domain.Entities;

namespace RPWA.Application.Contacts.Queries.GetContacts;

public class ContactBriefDto
{
    public int Id { get; init; }

    public string Sin { get; init; } = null!;

    public string Name => $"{FirstName} {LastName}";

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ContactBriefDto>();
        }
    }
}
