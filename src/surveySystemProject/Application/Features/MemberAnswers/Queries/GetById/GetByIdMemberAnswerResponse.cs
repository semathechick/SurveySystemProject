using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAnswers.Queries.GetById;

public class GetByIdMemberAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Guid AnswerId { get; set; }
}