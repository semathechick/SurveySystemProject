using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.ToTable("QuestionAnswers").HasKey(qa => qa.Id);

        builder.Property(qa => qa.Id).HasColumnName("Id").IsRequired();
        builder.Property(qa => qa.QuestionId).HasColumnName("QuestionId").IsRequired();
        builder.Property(qa => qa.AnswerId).HasColumnName("AnswerId").IsRequired();
        builder.Property(qa => qa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(qa => qa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(qa => qa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(qa => !qa.DeletedDate.HasValue);
    }
}