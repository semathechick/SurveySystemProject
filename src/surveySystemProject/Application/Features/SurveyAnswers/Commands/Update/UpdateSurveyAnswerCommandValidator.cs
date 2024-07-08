using FluentValidation;

namespace Application.Features.SurveyAnswers.Commands.Update;

public class UpdateSurveyAnswerCommandValidator : AbstractValidator<UpdateSurveyAnswerCommand>
{
    public UpdateSurveyAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}