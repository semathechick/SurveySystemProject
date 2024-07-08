using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberAnswerConfiguration : IEntityTypeConfiguration<MemberAnswer>
{
    public void Configure(EntityTypeBuilder<MemberAnswer> builder)
    {
        builder.ToTable("MemberAnswers").HasKey(ma => ma.Id);

        builder.Property(ma => ma.Id).HasColumnName("Id").IsRequired();
        builder.Property(ma => ma.MemberId).HasColumnName("MemberId").IsRequired();
        builder.Property(ma => ma.AnswerId).HasColumnName("AnswerId").IsRequired();
        builder.Property(ma => ma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ma => ma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ma => ma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ma => !ma.DeletedDate.HasValue);
    }
}