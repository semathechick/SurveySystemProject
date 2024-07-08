using FluentValidation;

namespace Application.Features.MemberAnswers.Commands.Update;

public class UpdateMemberAnswerCommandValidator : AbstractValidator<UpdateMemberAnswerCommand>
{
    public UpdateMemberAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.AnswerId).NotEmpty();
    }
}