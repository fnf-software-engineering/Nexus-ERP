using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class CompanyBranchUserConfiguration : IEntityTypeConfiguration<CompanyBranchUser>
{
    public void Configure(EntityTypeBuilder<CompanyBranchUser> builder)
    {
        builder.ToTable("seg_usuario_filiais");

        builder.HasKey(x => new { x.UserId, x.CompanyId, x.BranchId });

        builder.Ignore(x => x.CompanyBranchUserId);
        builder.Ignore(x => x.Active);
        builder.Ignore(x => x.DefaultBranch);
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);

        builder.Property(x => x.UserId)
            .HasColumnName("id_usuario");

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa");

        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial");

        builder.HasOne(x => x.User)
            .WithMany(x => x.CompanyBranches)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

