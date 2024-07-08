using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyAnswers;

public interface ISurveyAnswerService
{
    Task<SurveyAnswer?> GetAsync(
        Expression<Func<SurveyAnswer, bool>> predicate,
        Func<IQueryable<SurveyAnswer>, IIncludableQueryable<SurveyAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SurveyAnswer>?> GetListAsync(
        Expression<Func<SurveyAnswer, bool>>? predicate = null,
        Func<IQueryable<SurveyAnswer>, IOrderedQueryable<SurveyAnswer>>? orderBy = null,
        Func<IQueryable<SurveyAnswer>, IIncludableQueryable<SurveyAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SurveyAnswer> AddAsync(SurveyAnswer surveyAnswer);
    Task<SurveyAnswer> UpdateAsync(SurveyAnswer surveyAnswer);
    Task<SurveyAnswer> DeleteAsync(SurveyAnswer surveyAnswer, bool permanent = false);
}
