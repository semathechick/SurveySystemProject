using FluentValidation;

namespace Application.Features.SurveyAnswers.Commands.Create;

public class CreateSurveyAnswerCommandValidator : AbstractValidator<CreateSurveyAnswerCommand>
{
    public CreateSurveyAnswerCommandValidator()
    {
        RuleFor(c => c.SurveyId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}