using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class PermissionsConfiguration : IEntityTypeConfiguration<Permissions>
{
    public void Configure(EntityTypeBuilder<Permissions> builder)
    {
        builder.ToTable("seg_permissoes");

        builder.HasKey(x => x.IdPermission);

        builder.Property(x => x.IdPermission)
            .HasColumnName("id_permissao")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Module)
            .HasColumnName("modulo")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Resource)
            .HasColumnName("recurso")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Action)
            .HasColumnName("acao")
            .HasMaxLength(50)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(250);

        builder.Property(x => x.Active)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();
    }
}

