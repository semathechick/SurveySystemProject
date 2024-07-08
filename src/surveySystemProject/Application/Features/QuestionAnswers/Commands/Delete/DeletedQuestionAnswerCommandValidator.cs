using FluentValidation;

namespace Application.Features.QuestionAnswers.Commands.Delete;

public class DeleteQuestionAnswerCommandValidator : AbstractValidator<DeleteQuestionAnswerCommand>
{
    public DeleteQuestionAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}