using Application.Features.SurveyAnswers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SurveyAnswers.Rules;

public class SurveyAnswerBusinessRules : BaseBusinessRules
{
    private readonly ISurveyAnswerRepository _surveyAnswerRepository;
    private readonly ILocalizationService _localizationService;

    public SurveyAnswerBusinessRules(ISurveyAnswerRepository surveyAnswerRepository, ILocalizationService localizationService)
    {
        _surveyAnswerRepository = surveyAnswerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SurveyAnswersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SurveyAnswerShouldExistWhenSelected(SurveyAnswer? surveyAnswer)
    {
        if (surveyAnswer == null)
            await throwBusinessException(SurveyAnswersBusinessMessages.SurveyAnswerNotExists);
    }

    public async Task SurveyAnswerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SurveyAnswer? surveyAnswer = await _surveyAnswerRepository.GetAsync(
            predicate: sa => sa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyAnswerShouldExistWhenSelected(surveyAnswer);
    }
}