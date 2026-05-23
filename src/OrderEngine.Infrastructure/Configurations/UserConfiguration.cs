using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("seg_usuarios");

        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
            .HasColumnName("id_usuario")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("nome")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Login)
            .HasColumnName("login")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("senha_hash")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.IsBlocked)
            .HasColumnName("bloqueado")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.LastLoginAt)
            .HasColumnName("data_ultimo_login");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");

        builder.HasIndex(x => x.Email)
            .HasDatabaseName("ux_usuario_email")
            .IsUnique();

        builder.HasIndex(x => x.Login)
            .HasDatabaseName("ux_usuario_login")
            .IsUnique();
    }
}

