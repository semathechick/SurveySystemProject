using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberQuestions.Commands.Create;

public class CreatedMemberQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid QuestionId { get; set; }
}