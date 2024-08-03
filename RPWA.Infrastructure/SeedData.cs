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

        context.Contacts.AddRange(
            new Contact
            {
                Id = 1,
                Sin = "118 444 827",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now,
                Gender = Gender.male,
                YearlyIncome = 80000,
                PhoneNumber = "613-123-4567",
                Email = "john@web.com",
                Website = "www.johndoe.me",
                IsFavorite = false
            }
        );

        context.SaveChanges();
    }
}
