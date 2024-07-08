using Application.Features.MemberAnswers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MemberAnswers;

public class MemberAnswerManager : IMemberAnswerService
{
    private readonly IMemberAnswerRepository _memberAnswerRepository;
    private readonly MemberAnswerBusinessRules _memberAnswerBusinessRules;

    public MemberAnswerManager(IMemberAnswerRepository memberAnswerRepository, MemberAnswerBusinessRules memberAnswerBusinessRules)
    {
        _memberAnswerRepository = memberAnswerRepository;
        _memberAnswerBusinessRules = memberAnswerBusinessRules;
    }

    public async Task<MemberAnswer?> GetAsync(
        Expression<Func<MemberAnswer, bool>> predicate,
        Func<IQueryable<MemberAnswer>, IIncludableQueryable<MemberAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        MemberAnswer? memberAnswer = await _memberAnswerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return memberAnswer;
    }

    public async Task<IPaginate<MemberAnswer>?> GetListAsync(
        Expression<Func<MemberAnswer, bool>>? predicate = null,
        Func<IQueryable<MemberAnswer>, IOrderedQueryable<MemberAnswer>>? orderBy = null,
        Func<IQueryable<MemberAnswer>, IIncludableQueryable<MemberAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<MemberAnswer> memberAnswerList = await _memberAnswerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return memberAnswerList;
    }

    public async Task<MemberAnswer> AddAsync(MemberAnswer memberAnswer)
    {
        MemberAnswer addedMemberAnswer = await _memberAnswerRepository.AddAsync(memberAnswer);

        return addedMemberAnswer;
    }

    public async Task<MemberAnswer> UpdateAsync(MemberAnswer memberAnswer)
    {
        MemberAnswer updatedMemberAnswer = await _memberAnswerRepository.UpdateAsync(memberAnswer);

        return updatedMemberAnswer;
    }

    public async Task<MemberAnswer> DeleteAsync(MemberAnswer memberAnswer, bool permanent = false)
    {
        MemberAnswer deletedMemberAnswer = await _memberAnswerRepository.DeleteAsync(memberAnswer);

        return deletedMemberAnswer;
    }
}
