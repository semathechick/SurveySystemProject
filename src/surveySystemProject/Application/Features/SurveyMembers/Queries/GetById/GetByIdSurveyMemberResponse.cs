using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyMembers.Queries.GetById;

public class GetByIdSurveyMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
}