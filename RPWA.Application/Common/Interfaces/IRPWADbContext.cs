using Microsoft.EntityFrameworkCore;
using RPWA.Domain.Entities;

namespace RPWA.Application.Common.Interfaces;

public interface IRPWADbContext
{
    DbSet<Contact> Contact { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
