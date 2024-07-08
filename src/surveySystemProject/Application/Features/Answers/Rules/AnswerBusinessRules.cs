using Application.Features.Answers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Answers.Rules;

public class AnswerBusinessRules : BaseBusinessRules
{
    private readonly IAnswerRepository _answerRepository;
    private readonly ILocalizationService _localizationService;

    public AnswerBusinessRules(IAnswerRepository answerRepository, ILocalizationService localizationService)
    {
        _answerRepository = answerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AnswersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AnswerShouldExistWhenSelected(Answer? answer)
    {
        if (answer == null)
            await throwBusinessException(AnswersBusinessMessages.AnswerNotExists);
    }

    public async Task AnswerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Answer? answer = await _answerRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AnswerShouldExistWhenSelected(answer);
    }
}