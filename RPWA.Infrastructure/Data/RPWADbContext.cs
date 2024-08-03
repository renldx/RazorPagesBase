using Microsoft.EntityFrameworkCore;
using RPWA.Application.Common.Interfaces;
using RPWA.Domain.Entities;

namespace RPWA.Infrastructure.Data;

public class RPWADbContext(DbContextOptions<RPWADbContext> options)
    : DbContext(options),
        IRPWADbContext
{
    public DbSet<Contact> Contact { get; set; } = default!;
}
