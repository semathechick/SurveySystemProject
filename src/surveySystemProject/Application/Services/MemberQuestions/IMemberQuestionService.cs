using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberQuestions;

public interface IMemberQuestionService
{
    Task<MemberQuestion?> GetAsync(
        Expression<Func<MemberQuestion, bool>> predicate,
        Func<IQueryable<MemberQuestion>, IIncludableQueryable<MemberQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MemberQuestion>?> GetListAsync(
        Expression<Func<MemberQuestion, bool>>? predicate = null,
        Func<IQueryable<MemberQuestion>, IOrderedQueryable<MemberQuestion>>? orderBy = null,
        Func<IQueryable<MemberQuestion>, IIncludableQueryable<MemberQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MemberQuestion> AddAsync(MemberQuestion memberQuestion);
    Task<MemberQuestion> UpdateAsync(MemberQuestion memberQuestion);
    Task<MemberQuestion> DeleteAsync(MemberQuestion memberQuestion, bool permanent = false);
}
