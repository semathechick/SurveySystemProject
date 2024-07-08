using Application.Features.MemberQuestions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.MemberQuestions.Rules;

public class MemberQuestionBusinessRules : BaseBusinessRules
{
    private readonly IMemberQuestionRepository _memberQuestionRepository;
    private readonly ILocalizationService _localizationService;

    public MemberQuestionBusinessRules(IMemberQuestionRepository memberQuestionRepository, ILocalizationService localizationService)
    {
        _memberQuestionRepository = memberQuestionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, MemberQuestionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task MemberQuestionShouldExistWhenSelected(MemberQuestion? memberQuestion)
    {
        if (memberQuestion == null)
            await throwBusinessException(MemberQuestionsBusinessMessages.MemberQuestionNotExists);
    }

    public async Task MemberQuestionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        MemberQuestion? memberQuestion = await _memberQuestionRepository.GetAsync(
            predicate: mq => mq.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await MemberQuestionShouldExistWhenSelected(memberQuestion);
    }
}