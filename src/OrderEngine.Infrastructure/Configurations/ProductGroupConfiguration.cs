using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.ToTable("prod_grupos");

        builder.HasKey(x => x.ProductGroupId);

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.ProductGroupId)
            .HasColumnName("id_grupo")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("descricao")
            .HasMaxLength(100)
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