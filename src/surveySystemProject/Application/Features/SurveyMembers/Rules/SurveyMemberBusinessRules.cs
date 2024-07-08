using Application.Features.SurveyMembers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SurveyMembers.Rules;

public class SurveyMemberBusinessRules : BaseBusinessRules
{
    private readonly ISurveyMemberRepository _surveyMemberRepository;
    private readonly ILocalizationService _localizationService;

    public SurveyMemberBusinessRules(ISurveyMemberRepository surveyMemberRepository, ILocalizationService localizationService)
    {
        _surveyMemberRepository = surveyMemberRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SurveyMembersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SurveyMemberShouldExistWhenSelected(SurveyMember? surveyMember)
    {
        if (surveyMember == null)
            await throwBusinessException(SurveyMembersBusinessMessages.SurveyMemberNotExists);
    }

    public async Task SurveyMemberIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SurveyMember? surveyMember = await _surveyMemberRepository.GetAsync(
            predicate: sm => sm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyMemberShouldExistWhenSelected(surveyMember);
    }
}