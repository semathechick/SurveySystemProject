using FluentValidation;

namespace Application.Features.Answers.Commands.Create;

public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
{
    public CreateAnswerCommandValidator()
    {
        RuleFor(c => c.UserAnswer).NotEmpty();
    }
}