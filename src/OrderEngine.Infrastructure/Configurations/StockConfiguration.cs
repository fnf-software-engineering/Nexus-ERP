using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("est_estoques");

        builder.HasKey(x => x.StockId);

        builder.Property(x => x.StockId)
            .HasColumnName("id_estoque")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.ProductId)
            .HasColumnName("id_produto")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.CurrentQuantity)
            .HasColumnName("quantidade_atual")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.ReservedQuantity)
            .HasColumnName("quantidade_reservada")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.AverageCost)
            .HasColumnName("custo_medio")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.LastMovementDate)
            .HasColumnName("data_ultima_mov");

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(x => x.AvailableQuantity);

        builder.HasIndex(x => new { x.CompanyId, x.BranchId, x.ProductId })
            .IsUnique()
            .HasDatabaseName("ux_estoque_empresa_filial_produto");
    }
}