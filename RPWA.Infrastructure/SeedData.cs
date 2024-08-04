using Bogus;
using Bogus.Extensions.Canada;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPWA.Domain.Entities;
using RPWA.Domain.Enums;
using RPWA.Infrastructure.Data;

namespace RPWA.Infrastructure;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new RPWADbContext(
            serviceProvider.GetRequiredService<DbContextOptions<RPWADbContext>>()
        );

        if (context == null || context.Contacts == null)
        {
            throw new ArgumentNullException("context");
        }

        if (context.Contacts.Any())
        {
            return;
        }

        var fakeContact = new Faker<Contact>()
            .RuleFor(c => c.Sin, f => f.Person.Sin())
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.DateOfBirth, f => f.Person.DateOfBirth)
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.YearlyIncome, f => f.Random.Decimal(50000m, 100000))
            .RuleFor(c => c.PhoneNumber, f => f.Person.Phone)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Website, f => f.Person.Website)
            .RuleFor(c => c.IsFavorite, f => f.Random.Bool());

        for (var i = 0; i < 10; i++)
        {
            context.Contacts.Add(fakeContact.Generate());
        }

        context.SaveChanges();
    }
}
