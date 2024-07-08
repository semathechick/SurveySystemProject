using FluentValidation;

namespace Application.Features.MemberAnswers.Commands.Delete;

public class DeleteMemberAnswerCommandValidator : AbstractValidator<DeleteMemberAnswerCommand>
{
    public DeleteMemberAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}