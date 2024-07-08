using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.QuestionAnswers;

public interface IQuestionAnswerService
{
    Task<QuestionAnswer?> GetAsync(
        Expression<Func<QuestionAnswer, bool>> predicate,
        Func<IQueryable<QuestionAnswer>, IIncludableQueryable<QuestionAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<QuestionAnswer>?> GetListAsync(
        Expression<Func<QuestionAnswer, bool>>? predicate = null,
        Func<IQueryable<QuestionAnswer>, IOrderedQueryable<QuestionAnswer>>? orderBy = null,
        Func<IQueryable<QuestionAnswer>, IIncludableQueryable<QuestionAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<QuestionAnswer> AddAsync(QuestionAnswer questionAnswer);
    Task<QuestionAnswer> UpdateAsync(QuestionAnswer questionAnswer);
    Task<QuestionAnswer> DeleteAsync(QuestionAnswer questionAnswer, bool permanent = false);
}
