using FluentValidation;

namespace Application.Features.SurveyAnswers.Commands.Delete;

public class DeleteSurveyAnswerCommandValidator : AbstractValidator<DeleteSurveyAnswerCommand>
{
    public DeleteSurveyAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}