using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAnswers.Commands.Create;

public class CreatedMemberAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AnswerId { get; set; }
}