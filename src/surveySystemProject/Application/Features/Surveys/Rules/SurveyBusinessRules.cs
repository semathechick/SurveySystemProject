using Application.Features.Surveys.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Surveys.Rules;

public class SurveyBusinessRules : BaseBusinessRules
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly ILocalizationService _localizationService;

    public SurveyBusinessRules(ISurveyRepository surveyRepository, ILocalizationService localizationService)
    {
        _surveyRepository = surveyRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SurveysBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SurveyShouldExistWhenSelected(Survey? survey)
    {
        if (survey == null)
            await throwBusinessException(SurveysBusinessMessages.SurveyNotExists);
    }

    public async Task SurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyShouldExistWhenSelected(survey);
    }
}