using Microsoft.EntityFrameworkCore;
using RPWA.Domain.Entities;

namespace RPWA.Infrastructure.Data;

public class RPWAContext(DbContextOptions<RPWAContext> options) : DbContext(options)
{
    public DbSet<Contact> Contact { get; set; } = default!;
}
