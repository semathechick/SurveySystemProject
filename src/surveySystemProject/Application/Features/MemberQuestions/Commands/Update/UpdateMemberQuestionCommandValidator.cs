using FluentValidation;

namespace Application.Features.MemberQuestions.Commands.Update;

public class UpdateMemberQuestionCommandValidator : AbstractValidator<UpdateMemberQuestionCommand>
{
    public UpdateMemberQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
    }
}