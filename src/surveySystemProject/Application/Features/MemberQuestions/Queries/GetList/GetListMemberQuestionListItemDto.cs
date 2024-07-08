using NArchitecture.Core.Application.Dtos;

namespace Application.Features.MemberQuestions.Queries.GetList;

public class GetListMemberQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid QuestionId { get; set; }
}