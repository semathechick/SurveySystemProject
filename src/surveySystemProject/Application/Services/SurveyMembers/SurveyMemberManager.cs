using Application.Features.SurveyMembers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyMembers;

public class SurveyMemberManager : ISurveyMemberService
{
    private readonly ISurveyMemberRepository _surveyMemberRepository;
    private readonly SurveyMemberBusinessRules _surveyMemberBusinessRules;

    public SurveyMemberManager(ISurveyMemberRepository surveyMemberRepository, SurveyMemberBusinessRules surveyMemberBusinessRules)
    {
        _surveyMemberRepository = surveyMemberRepository;
        _surveyMemberBusinessRules = surveyMemberBusinessRules;
    }

    public async Task<SurveyMember?> GetAsync(
        Expression<Func<SurveyMember, bool>> predicate,
        Func<IQueryable<SurveyMember>, IIncludableQueryable<SurveyMember, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SurveyMember? surveyMember = await _surveyMemberRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return surveyMember;
    }

    public async Task<IPaginate<SurveyMember>?> GetListAsync(
        Expression<Func<SurveyMember, bool>>? predicate = null,
        Func<IQueryable<SurveyMember>, IOrderedQueryable<SurveyMember>>? orderBy = null,
        Func<IQueryable<SurveyMember>, IIncludableQueryable<SurveyMember, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SurveyMember> surveyMemberList = await _surveyMemberRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return surveyMemberList;
    }

    public async Task<SurveyMember> AddAsync(SurveyMember surveyMember)
    {
        SurveyMember addedSurveyMember = await _surveyMemberRepository.AddAsync(surveyMember);

        return addedSurveyMember;
    }

    public async Task<SurveyMember> UpdateAsync(SurveyMember surveyMember)
    {
        SurveyMember updatedSurveyMember = await _surveyMemberRepository.UpdateAsync(surveyMember);

        return updatedSurveyMember;
    }

    public async Task<SurveyMember> DeleteAsync(SurveyMember surveyMember, bool permanent = false)
    {
        SurveyMember deletedSurveyMember = await _surveyMemberRepository.DeleteAsync(surveyMember);

        return deletedSurveyMember;
    }
}
