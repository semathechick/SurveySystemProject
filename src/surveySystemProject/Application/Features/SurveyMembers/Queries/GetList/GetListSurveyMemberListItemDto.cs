using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SurveyMembers.Queries.GetList;

public class GetListSurveyMemberListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid SurveyId { get; set; }
}