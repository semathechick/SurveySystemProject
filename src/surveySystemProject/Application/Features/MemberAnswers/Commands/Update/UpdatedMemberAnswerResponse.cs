using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAnswers.Commands.Update;

public class UpdatedMemberAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AnswerId { get; set; }
}