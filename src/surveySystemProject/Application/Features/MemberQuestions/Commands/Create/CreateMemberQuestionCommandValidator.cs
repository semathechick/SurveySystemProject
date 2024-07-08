using FluentValidation;

namespace Application.Features.MemberQuestions.Commands.Create;

public class CreateMemberQuestionCommandValidator : AbstractValidator<CreateMemberQuestionCommand>
{
    public CreateMemberQuestionCommandValidator()
    {
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
    }
}