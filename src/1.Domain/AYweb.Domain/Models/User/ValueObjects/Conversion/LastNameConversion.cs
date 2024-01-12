using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AYweb.Domain.Models.User.ValueObjects.Conversion;

public class LastNameConversion : ValueConverter<LastName, string>
{
    public LastNameConversion() : base(c => c.Value, c => LastName.FromString(c)) { }
}

