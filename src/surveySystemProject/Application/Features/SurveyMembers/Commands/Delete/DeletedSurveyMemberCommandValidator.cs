using FluentValidation;

namespace Application.Features.SurveyMembers.Commands.Delete;

public class DeleteSurveyMemberCommandValidator : AbstractValidator<DeleteSurveyMemberCommand>
{
    public DeleteSurveyMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}