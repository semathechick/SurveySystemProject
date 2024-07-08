using FluentValidation;

namespace Application.Features.MemberAnswers.Commands.Create;

public class CreateMemberAnswerCommandValidator : AbstractValidator<CreateMemberAnswerCommand>
{
    public CreateMemberAnswerCommandValidator()
    {
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}