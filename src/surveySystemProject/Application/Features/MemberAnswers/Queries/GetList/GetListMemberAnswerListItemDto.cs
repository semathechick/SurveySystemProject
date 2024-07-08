using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MemberAnswers.Queries.GetList;

public class GetListMemberAnswerListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AnswerId { get; set; }
}