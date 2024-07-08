using FluentValidation;

namespace Application.Features.SurveyMembers.Commands.Create;

public class CreateSurveyMemberCommandValidator : AbstractValidator<CreateSurveyMemberCommand>
{
    public CreateSurveyMemberCommandValidator()
    {
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}