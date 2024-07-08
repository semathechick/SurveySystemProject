using FluentValidation;

namespace Application.Features.SurveyMembers.Commands.Update;

public class UpdateSurveyMemberCommandValidator : AbstractValidator<UpdateSurveyMemberCommand>
{
    public UpdateSurveyMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}