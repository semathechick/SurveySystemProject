using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SurveyMemberConfiguration : IEntityTypeConfiguration<SurveyMember>
{
    public void Configure(EntityTypeBuilder<SurveyMember> builder)
    {
        builder.ToTable("SurveyMembers").HasKey(sm => sm.Id);

        builder.Property(sm => sm.Id).HasColumnName("Id").IsRequired();
        builder.Property(sm => sm.MemberId).HasColumnName("MemberId").IsRequired();
        builder.Property(sm => sm.SurveyId).HasColumnName("SurveyId").IsRequired();
        builder.Property(sm => sm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sm => sm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sm => sm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sm => !sm.DeletedDate.HasValue);
    }
}