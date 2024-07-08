using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyMembers.Commands.Create;

public class CreatedSurveyMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
}