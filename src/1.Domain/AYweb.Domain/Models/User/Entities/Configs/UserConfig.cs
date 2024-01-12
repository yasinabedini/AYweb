using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.User.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.User.Entities.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(t => t.FirstName).HasConversion<FirstNameConversion>().HasMaxLength(60).IsRequired();

        builder.Property(t => t.LastName).HasConversion<LastNameConversion>().HasMaxLength(60).IsRequired();

        builder.Property(t => t.PhoneNumber).HasConversion<PhoneNumberConversion>().HasMaxLength(20).IsRequired();

        builder.Property(t => t.Email).HasMaxLength(100).IsRequired();

        builder.Property(t => t.VerificationCode).HasConversion<VerificationCodeConversion>().HasMaxLength(100).IsRequired();

        builder.HasMany(t => t.Transactions);
        builder.HasMany(t => t.RolesList);
        builder.HasMany(t => t.Notifications);

    }
}
