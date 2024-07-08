using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberQuestions.Queries.GetById;

public class GetByIdMemberQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid QuestionId { get; set; }
}