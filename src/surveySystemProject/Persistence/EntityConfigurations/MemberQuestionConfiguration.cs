using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MemberQuestionConfiguration : IEntityTypeConfiguration<MemberQuestion>
{
    public void Configure(EntityTypeBuilder<MemberQuestion> builder)
    {
        builder.ToTable("MemberQuestions").HasKey(mq => mq.Id);

        builder.Property(mq => mq.Id).HasColumnName("Id").IsRequired();
        builder.Property(mq => mq.MemberId).HasColumnName("MemberId").IsRequired();
        builder.Property(mq => mq.QuestionId).HasColumnName("QuestionId").IsRequired();
        builder.Property(mq => mq.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mq => mq.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mq => mq.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mq => !mq.DeletedDate.HasValue);
    }
}