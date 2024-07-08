using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Answers.Constants;
using Application.Features.Members.Constants;
using Application.Features.MemberAnswers.Constants;
using Application.Features.Questions.Constants;
using Application.Features.MemberQuestions.Constants;
using Application.Features.Surveys.Constants;
using Application.Features.SurveyAnswers.Constants;
using Application.Features.SurveyMembers.Constants;
using Application.Features.QuestionAnswers.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Answers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AnswersOperationClaims.Admin },
                new() { Id = ++lastId, Name = AnswersOperationClaims.Read },
                new() { Id = ++lastId, Name = AnswersOperationClaims.Write },
                new() { Id = ++lastId, Name = AnswersOperationClaims.Create },
                new() { Id = ++lastId, Name = AnswersOperationClaims.Update },
                new() { Id = ++lastId, Name = AnswersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberAnswers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberAnswersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Questions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Read },
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Write },
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Create },
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Update },
                new() { Id = ++lastId, Name = QuestionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberQuestions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberQuestionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Surveys CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SurveysOperationClaims.Admin },
                new() { Id = ++lastId, Name = SurveysOperationClaims.Read },
                new() { Id = ++lastId, Name = SurveysOperationClaims.Write },
                new() { Id = ++lastId, Name = SurveysOperationClaims.Create },
                new() { Id = ++lastId, Name = SurveysOperationClaims.Update },
                new() { Id = ++lastId, Name = SurveysOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SurveyAnswers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Admin },
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Read },
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Write },
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Create },
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Update },
                new() { Id = ++lastId, Name = SurveyAnswersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SurveyMembers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Read },
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Write },
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Create },
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Update },
                new() { Id = ++lastId, Name = SurveyMembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region QuestionAnswers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Admin },
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Read },
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Write },
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Create },
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Update },
                new() { Id = ++lastId, Name = QuestionAnswersOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
