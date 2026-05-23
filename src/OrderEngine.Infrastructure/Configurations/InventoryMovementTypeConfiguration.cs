using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;
using OrderEngine.Domain.Enums;

namespace OrderEngine.Infrastructure.Configurations;

public class InventoryMovementTypeConfiguration : IEntityTypeConfiguration<InventoryMovementType>
{
    public void Configure(EntityTypeBuilder<InventoryMovementType> builder)
    {
        builder.ToTable("est_tipos_movimentacao");

        builder.HasKey(x => x.InventoryMovementTypeId);

        builder.Property(x => x.InventoryMovementTypeId)
            .HasColumnName("id_tipo_movimentacao")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("codigo")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.MovementType)
            .HasColumnName("tipo")
            .HasColumnType("char(1)")
            .HasConversion(
                v => v == MovementType.Inbound ? "E" : "S",
                v => v == "E" ? MovementType.Inbound : MovementType.Outbound)
            .IsRequired();

        builder.Property(x => x.UpdateCost)
            .HasColumnName("atualiza_custo")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.MoveInventory)
            .HasColumnName("movimenta_estoque")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();
    }
}