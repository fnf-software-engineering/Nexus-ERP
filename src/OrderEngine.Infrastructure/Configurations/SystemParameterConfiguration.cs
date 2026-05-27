using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;
using OrderEngine.Domain.Enums;

namespace OrderEngine.Infrastructure.Configurations;

public class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameter>
{
    public void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        builder.ToTable("sis_parametros");

        builder.HasKey(x => x.ParameterId);

        builder.Property(x => x.ParameterId)
            .HasColumnName("id_parametro")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid");

        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial")
            .HasColumnType("uuid");

        builder.Property(x => x.Key)
            .HasColumnName("chave")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnName("valor")
            .HasColumnType("text");

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(250);

        builder.Property(x => x.Type)
            .HasColumnName("tipo")
            .HasMaxLength(30)
            .HasConversion(
                value => value.ToString().ToUpperInvariant(),
                value => Enum.Parse<ParameterType>(value, true))
            .HasDefaultValue(ParameterType.String)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");

        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
