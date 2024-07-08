using Application.Features.QuestionAnswers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.QuestionAnswers;

public class QuestionAnswerManager : IQuestionAnswerService
{
    private readonly IQuestionAnswerRepository _questionAnswerRepository;
    private readonly QuestionAnswerBusinessRules _questionAnswerBusinessRules;

    public QuestionAnswerManager(IQuestionAnswerRepository questionAnswerRepository, QuestionAnswerBusinessRules questionAnswerBusinessRules)
    {
        _questionAnswerRepository = questionAnswerRepository;
        _questionAnswerBusinessRules = questionAnswerBusinessRules;
    }

    public async Task<QuestionAnswer?> GetAsync(
        Expression<Func<QuestionAnswer, bool>> predicate,
        Func<IQueryable<QuestionAnswer>, IIncludableQueryable<QuestionAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        QuestionAnswer? questionAnswer = await _questionAnswerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return questionAnswer;
    }

    public async Task<IPaginate<QuestionAnswer>?> GetListAsync(
        Expression<Func<QuestionAnswer, bool>>? predicate = null,
        Func<IQueryable<QuestionAnswer>, IOrderedQueryable<QuestionAnswer>>? orderBy = null,
        Func<IQueryable<QuestionAnswer>, IIncludableQueryable<QuestionAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<QuestionAnswer> questionAnswerList = await _questionAnswerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return questionAnswerList;
    }

    public async Task<QuestionAnswer> AddAsync(QuestionAnswer questionAnswer)
    {
        QuestionAnswer addedQuestionAnswer = await _questionAnswerRepository.AddAsync(questionAnswer);

        return addedQuestionAnswer;
    }

    public async Task<QuestionAnswer> UpdateAsync(QuestionAnswer questionAnswer)
    {
        QuestionAnswer updatedQuestionAnswer = await _questionAnswerRepository.UpdateAsync(questionAnswer);

        return updatedQuestionAnswer;
    }

    public async Task<QuestionAnswer> DeleteAsync(QuestionAnswer questionAnswer, bool permanent = false)
    {
        QuestionAnswer deletedQuestionAnswer = await _questionAnswerRepository.DeleteAsync(questionAnswer);

        return deletedQuestionAnswer;
    }
}
