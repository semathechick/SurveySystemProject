using NArchitecture.Core.Application.Responses;

namespace Application.Features.MemberQuestions.Commands.Delete;

public class DeletedMemberQuestionResponse : IResponse
{
    public Guid Id { get; set; }
}