using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AYweb.Domain.Common.ValueObjects.Conversion;

public class DescriptionConversion : ValueConverter<Description, string>
{
    public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
    {

    }
}
