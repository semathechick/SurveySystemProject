using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberAnswers.Commands.Delete;

public class DeletedMemberAnswerResponse : IResponse
{
    public Guid Id { get; set; }
}