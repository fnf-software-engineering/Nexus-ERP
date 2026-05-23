using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class PermissionsProfileConfiguration : IEntityTypeConfiguration<PermissionsProfile>
{
    public void Configure(EntityTypeBuilder<PermissionsProfile> builder)
    {
        builder.ToTable("seg_perfil_permissoes");

        builder.HasKey(x => new { x.ProfileId, x.PermissionId });

        builder.Property(x => x.ProfileId)
            .HasColumnName("id_perfil");

        builder.Property(x => x.PermissionId)
            .HasColumnName("id_permissao");

        builder.Property(x => x.Allowed)
            .HasColumnName("permitido")
            .HasDefaultValue(true)
            .IsRequired();

        builder.HasOne<Profiles>()
            .WithMany()
            .HasForeignKey(x => x.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Permissions>()
            .WithMany()
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

