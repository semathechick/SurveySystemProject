using Application.Features.MemberQuestions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberQuestions;

public class MemberQuestionManager : IMemberQuestionService
{
    private readonly IMemberQuestionRepository _memberQuestionRepository;
    private readonly MemberQuestionBusinessRules _memberQuestionBusinessRules;

    public MemberQuestionManager(IMemberQuestionRepository memberQuestionRepository, MemberQuestionBusinessRules memberQuestionBusinessRules)
    {
        _memberQuestionRepository = memberQuestionRepository;
        _memberQuestionBusinessRules = memberQuestionBusinessRules;
    }

    public async Task<MemberQuestion?> GetAsync(
        Expression<Func<MemberQuestion, bool>> predicate,
        Func<IQueryable<MemberQuestion>, IIncludableQueryable<MemberQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MemberQuestion? memberQuestion = await _memberQuestionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return memberQuestion;
    }

    public async Task<IPaginate<MemberQuestion>?> GetListAsync(
        Expression<Func<MemberQuestion, bool>>? predicate = null,
        Func<IQueryable<MemberQuestion>, IOrderedQueryable<MemberQuestion>>? orderBy = null,
        Func<IQueryable<MemberQuestion>, IIncludableQueryable<MemberQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MemberQuestion> memberQuestionList = await _memberQuestionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberQuestionList;
    }

    public async Task<MemberQuestion> AddAsync(MemberQuestion memberQuestion)
    {
        MemberQuestion addedMemberQuestion = await _memberQuestionRepository.AddAsync(memberQuestion);

        return addedMemberQuestion;
    }

    public async Task<MemberQuestion> UpdateAsync(MemberQuestion memberQuestion)
    {
        MemberQuestion updatedMemberQuestion = await _memberQuestionRepository.UpdateAsync(memberQuestion);

        return updatedMemberQuestion;
    }

    public async Task<MemberQuestion> DeleteAsync(MemberQuestion memberQuestion, bool permanent = false)
    {
        MemberQuestion deletedMemberQuestion = await _memberQuestionRepository.DeleteAsync(memberQuestion);

        return deletedMemberQuestion;
    }
}
