using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AYweb.Domain.Models.User.ValueObjects.Conversion;

public class VerificationCodeConversion : ValueConverter<VerificationCode, string>
{    
    public VerificationCodeConversion() : base(c => c.Value, c => VerificationCode.FromString(c)) { }
}

