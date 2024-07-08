using Application.Features.MemberAnswers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MemberAnswers.Rules;

public class MemberAnswerBusinessRules : BaseBusinessRules
{
    private readonly IMemberAnswerRepository _memberAnswerRepository;
    private readonly ILocalizationService _localizationService;

    public MemberAnswerBusinessRules(IMemberAnswerRepository memberAnswerRepository, ILocalizationService localizationService)
    {
        _memberAnswerRepository = memberAnswerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MemberAnswersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberAnswerShouldExistWhenSelected(MemberAnswer? memberAnswer)
    {
        if (memberAnswer == null)
            await throwBusinessException(MemberAnswersBusinessMessages.MemberAnswerNotExists);
    }

    public async Task MemberAnswerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MemberAnswer? memberAnswer = await _memberAnswerRepository.GetAsync(
            predicate: ma => ma.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberAnswerShouldExistWhenSelected(memberAnswer);
    }
}