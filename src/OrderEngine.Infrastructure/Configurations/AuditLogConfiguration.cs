using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("aud_logs");

        builder.HasKey(x => x.LogId);

        builder.Property(x => x.LogId)
            .HasColumnName("id_log")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("id_usuario")
            .HasColumnType("uuid");

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid");

        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial")
            .HasColumnType("uuid");

        builder.Property(x => x.OccurredAt)
            .HasColumnName("data_hora")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.Module)
            .HasColumnName("modulo")
            .HasMaxLength(100);

        builder.Property(x => x.EntityName)
            .HasColumnName("entidade")
            .HasMaxLength(100);

        builder.Property(x => x.RecordId)
            .HasColumnName("id_registro")
            .HasMaxLength(100);

        builder.Property(x => x.Action)
            .HasColumnName("acao")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(500);

        builder.Property(x => x.OriginIp)
            .HasColumnName("ip_origem")
            .HasMaxLength(50);

        builder.Property(x => x.UserAgent)
            .HasColumnName("user_agent")
            .HasMaxLength(500);

        builder.Property(x => x.IsSuccessful)
            .HasColumnName("sucesso")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.ErrorMessage)
            .HasColumnName("mensagem_erro")
            .HasColumnType("text");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
