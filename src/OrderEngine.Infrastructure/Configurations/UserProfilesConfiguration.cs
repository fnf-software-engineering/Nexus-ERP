using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class UserProfilesConfiguration : IEntityTypeConfiguration<UserProfiles>
{
    public void Configure(EntityTypeBuilder<UserProfiles> builder)
    {
        builder.ToTable("seg_usuario_perfis");

        builder.HasKey(x => new { x.UserId, x.ProfileId });

        builder.Property(x => x.UserId)
            .HasColumnName("id_usuario");

        builder.Property(x => x.ProfileId)
            .HasColumnName("id_perfil");

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey(x => x.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

