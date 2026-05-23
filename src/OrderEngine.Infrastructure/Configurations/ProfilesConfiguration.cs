using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class ProfilesConfiguration : IEntityTypeConfiguration<Profiles>
{
    public void Configure(EntityTypeBuilder<Profiles> builder)
    {
        builder.ToTable("seg_perfis");

        builder.HasKey(x => x.ProfileId);

        builder.Property(x => x.ProfileId)
            .HasColumnName("id_perfil")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(250);

        builder.Property(x => x.IsAdministrator)
            .HasColumnName("administrador")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");
    }
}

