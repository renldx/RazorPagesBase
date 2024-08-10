using RPWA.Domain.Enums;

namespace RPWA.Domain.Entities;

public class Contact
{
    // TODO: Shouldn't be here?
    public int Id { get; set; }

    public string Sin { get; set; } = default!;

    public string Name => $"{FirstName} {LastName}";

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }

    public Gender? Gender { get; set; }

    public decimal? YearlyIncome { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public bool IsFavorite { get; set; }
}
