using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AYweb.Domain.Models.User.ValueObjects.Conversion;

public class FirstNameConversion:ValueConverter<FirstName,string>
{
    public FirstNameConversion() : base(c => c.Value, c => FirstName.FromString(c)) { }
}

