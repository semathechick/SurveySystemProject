using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberAnswers;

public interface IMemberAnswerService
{
    Task<MemberAnswer?> GetAsync(
        Expression<Func<MemberAnswer, bool>> predicate,
        Func<IQueryable<MemberAnswer>, IIncludableQueryable<MemberAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MemberAnswer>?> GetListAsync(
        Expression<Func<MemberAnswer, bool>>? predicate = null,
        Func<IQueryable<MemberAnswer>, IOrderedQueryable<MemberAnswer>>? orderBy = null,
        Func<IQueryable<MemberAnswer>, IIncludableQueryable<MemberAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MemberAnswer> AddAsync(MemberAnswer memberAnswer);
    Task<MemberAnswer> UpdateAsync(MemberAnswer memberAnswer);
    Task<MemberAnswer> DeleteAsync(MemberAnswer memberAnswer, bool permanent = false);
}
