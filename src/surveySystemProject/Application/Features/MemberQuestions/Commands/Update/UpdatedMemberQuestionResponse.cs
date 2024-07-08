using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberQuestions.Commands.Update;

public class UpdatedMemberQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid QuestionId { get; set; }
}