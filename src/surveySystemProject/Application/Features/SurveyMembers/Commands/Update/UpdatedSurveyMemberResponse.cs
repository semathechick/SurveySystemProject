using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyMembers.Commands.Update;

public class UpdatedSurveyMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
}