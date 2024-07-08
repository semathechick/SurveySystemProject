using FluentValidation;

namespace Application.Features.QuestionAnswers.Commands.Update;

public class UpdateQuestionAnswerCommandValidator : AbstractValidator<UpdateQuestionAnswerCommand>
{
    public UpdateQuestionAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}