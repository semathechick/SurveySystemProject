using Application.Features.SurveyAnswers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyAnswers;

public class SurveyAnswerManager : ISurveyAnswerService
{
    private readonly ISurveyAnswerRepository _surveyAnswerRepository;
    private readonly SurveyAnswerBusinessRules _surveyAnswerBusinessRules;

    public SurveyAnswerManager(ISurveyAnswerRepository surveyAnswerRepository, SurveyAnswerBusinessRules surveyAnswerBusinessRules)
    {
        _surveyAnswerRepository = surveyAnswerRepository;
        _surveyAnswerBusinessRules = surveyAnswerBusinessRules;
    }

    public async Task<SurveyAnswer?> GetAsync(
        Expression<Func<SurveyAnswer, bool>> predicate,
        Func<IQueryable<SurveyAnswer>, IIncludableQueryable<SurveyAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SurveyAnswer? surveyAnswer = await _surveyAnswerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return surveyAnswer;
    }

    public async Task<IPaginate<SurveyAnswer>?> GetListAsync(
        Expression<Func<SurveyAnswer, bool>>? predicate = null,
        Func<IQueryable<SurveyAnswer>, IOrderedQueryable<SurveyAnswer>>? orderBy = null,
        Func<IQueryable<SurveyAnswer>, IIncludableQueryable<SurveyAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SurveyAnswer> surveyAnswerList = await _surveyAnswerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return surveyAnswerList;
    }

    public async Task<SurveyAnswer> AddAsync(SurveyAnswer surveyAnswer)
    {
        SurveyAnswer addedSurveyAnswer = await _surveyAnswerRepository.AddAsync(surveyAnswer);

        return addedSurveyAnswer;
    }

    public async Task<SurveyAnswer> UpdateAsync(SurveyAnswer surveyAnswer)
    {
        SurveyAnswer updatedSurveyAnswer = await _surveyAnswerRepository.UpdateAsync(surveyAnswer);

        return updatedSurveyAnswer;
    }

    public async Task<SurveyAnswer> DeleteAsync(SurveyAnswer surveyAnswer, bool permanent = false)
    {
        SurveyAnswer deletedSurveyAnswer = await _surveyAnswerRepository.DeleteAsync(surveyAnswer);

        return deletedSurveyAnswer;
    }
}
