﻿using Living.Domain.Entities.Users;

namespace Living.Infraestructure.Configuration;
internal class UserClaimsConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClaimType);

        builder.Property(x => x.ClaimValue);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserClaims)
            .HasForeignKey(x => x.UserId);
    }
}
