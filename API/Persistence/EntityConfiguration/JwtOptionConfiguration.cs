using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.EntityConfiguration;

public class JwtOptionConfiguration: IEntityTypeConfiguration<JwtOption>
{
    public void Configure(EntityTypeBuilder<JwtOption> builder)
    {
        builder.ToTable("JwtOptions").HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.JwtName).IsRequired();
        builder.Property(x => x.Secret).IsRequired();
        builder.Property(x=>x.Issuer).IsRequired();
        builder.Property(x=>x.Audience).IsRequired();
        builder.Property(x=>x.AccessTokenExpiration).IsRequired();

        builder.HasIndex(x => x.JwtName).IsUnique();
        var jwtOption = new JwtOption
        {
            Id = Guid.NewGuid(),
            JwtName = "Default",
            Secret = "LREHCRWI6U7SBIB0HFXP6F0H6BZS2EJ4KXSGZBTUPJFZJKEX2E33W8RDIOT7YB4V",
            Issuer = "example.com",
            Audience = "example.com",
            AccessTokenExpiration = 5
        };
        
        builder.HasData(jwtOption);
    }
}