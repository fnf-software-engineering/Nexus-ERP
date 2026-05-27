using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class LogDetailsConfiguration : IEntityTypeConfiguration<LogDetails>
{
    public void Configure(EntityTypeBuilder<LogDetails> builder)
    {
        builder.ToTable("aud_log_detalhes");

        builder.HasKey(x => x.LogDetailId);

        builder.Property(x => x.LogDetailId)
            .HasColumnName("id_log_detalhe")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LogId)
            .HasColumnName("id_log")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Field)
            .HasColumnName("campo")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.OldValue)
            .HasColumnName("valor_anterior")
            .HasColumnType("text");

        builder.Property(x => x.NewValue)
            .HasColumnName("valor_novo")
            .HasColumnType("text");

        builder.HasOne<AuditLog>()
            .WithMany(x => x.Details)
            .HasForeignKey(x => x.LogId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
