using FluentValidation;

namespace Application.Features.QuestionAnswers.Commands.Create;

public class CreateQuestionAnswerCommandValidator : AbstractValidator<CreateQuestionAnswerCommand>
{
    public CreateQuestionAnswerCommandValidator()
    {
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}