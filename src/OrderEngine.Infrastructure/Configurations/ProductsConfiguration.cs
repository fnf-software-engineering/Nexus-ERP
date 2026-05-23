using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("prod_produtos");

        builder.HasKey(x => x.ProductId);

        builder.Property(x => x.ProductId)
            .HasColumnName("id_produto")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("codigo")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ShortDescription)
            .HasColumnName("descricao_reduzida")
            .HasMaxLength(100);

        builder.Property(x => x.ProductGroupId)
            .HasColumnName("id_grupo")
            .HasColumnType("uuid");

        builder.Property(x => x.UnitMeasurementId)
            .HasColumnName("id_unidade")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Barcode)
            .HasColumnName("codigo_barras")
            .HasMaxLength(50);

        builder.Property(x => x.Reference)
            .HasColumnName("referencia")
            .HasMaxLength(50);

        builder.Property(x => x.ControlsStock)
            .HasColumnName("controla_estoque")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.AllowsSale)
            .HasColumnName("permite_venda")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.AllowsPurchase)
            .HasColumnName("permite_compra")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.SalePrice)
            .HasColumnName("preco_venda")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.CurrentCost)
            .HasColumnName("custo_atual")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.AverageCost)
            .HasColumnName("custo_medio")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.MinimumStock)
            .HasColumnName("estoque_minimo")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.MaximumStock)
            .HasColumnName("estoque_maximo")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        builder.Property(x => x.NetWeight)
            .HasColumnName("peso_liquido")
            .HasPrecision(18, 4);

        builder.Property(x => x.GrossWeight)
            .HasColumnName("peso_bruto")
            .HasPrecision(18, 4);

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

        builder.HasOne(x => x.ProductGroup)
            .WithMany()
            .HasForeignKey(x => x.ProductGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UnitMeasurement)
            .WithMany()
            .HasForeignKey(x => x.UnitMeasurementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Code)
            .IsUnique()
            .HasDatabaseName("ux_produto_codigo");

        builder.HasIndex(x => x.Description)
            .HasDatabaseName("ix_produto_descricao");
    }
}