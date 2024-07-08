using FluentValidation;

namespace Application.Features.MemberQuestions.Commands.Delete;

public class DeleteMemberQuestionCommandValidator : AbstractValidator<DeleteMemberQuestionCommand>
{
    public DeleteMemberQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}