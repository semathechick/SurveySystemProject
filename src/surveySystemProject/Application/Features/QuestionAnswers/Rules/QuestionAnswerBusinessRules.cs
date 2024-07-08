using Application.Features.QuestionAnswers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.QuestionAnswers.Rules;

public class QuestionAnswerBusinessRules : BaseBusinessRules
{
    private readonly IQuestionAnswerRepository _questionAnswerRepository;
    private readonly ILocalizationService _localizationService;

    public QuestionAnswerBusinessRules(IQuestionAnswerRepository questionAnswerRepository, ILocalizationService localizationService)
    {
        _questionAnswerRepository = questionAnswerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, QuestionAnswersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task QuestionAnswerShouldExistWhenSelected(QuestionAnswer? questionAnswer)
    {
        if (questionAnswer == null)
            await throwBusinessException(QuestionAnswersBusinessMessages.QuestionAnswerNotExists);
    }

    public async Task QuestionAnswerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        QuestionAnswer? questionAnswer = await _questionAnswerRepository.GetAsync(
            predicate: qa => qa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await QuestionAnswerShouldExistWhenSelected(questionAnswer);
    }
}