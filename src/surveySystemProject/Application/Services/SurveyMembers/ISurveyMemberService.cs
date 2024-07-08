using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyMembers;

public interface ISurveyMemberService
{
    Task<SurveyMember?> GetAsync(
        Expression<Func<SurveyMember, bool>> predicate,
        Func<IQueryable<SurveyMember>, IIncludableQueryable<SurveyMember, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SurveyMember>?> GetListAsync(
        Expression<Func<SurveyMember, bool>>? predicate = null,
        Func<IQueryable<SurveyMember>, IOrderedQueryable<SurveyMember>>? orderBy = null,
        Func<IQueryable<SurveyMember>, IIncludableQueryable<SurveyMember, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SurveyMember> AddAsync(SurveyMember surveyMember);
    Task<SurveyMember> UpdateAsync(SurveyMember surveyMember);
    Task<SurveyMember> DeleteAsync(SurveyMember surveyMember, bool permanent = false);
}
