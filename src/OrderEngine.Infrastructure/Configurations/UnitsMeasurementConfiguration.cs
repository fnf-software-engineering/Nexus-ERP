using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class UnitsMeasurementConfiguration : IEntityTypeConfiguration<UnitsMeasurement>
{
    public void Configure(EntityTypeBuilder<UnitsMeasurement> builder)
    {
        builder.ToTable("prod_unidades_medida");

        builder.HasKey(x => x.UnitsMeasurementId);

        builder.Property(x => x.UnitsMeasurementId)
            .HasColumnName("id_unidade")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Acronym)
            .HasColumnName("sigla")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DecimalPlaces)
            .HasColumnName("casas_decimais")
            .HasDefaultValue(2)
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