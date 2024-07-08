using NArchitecture.Core.Application.Responses;

namespace Application.Features.Answers.Commands.Delete;

public class DeletedAnswerResponse : IResponse
{
    public Guid Id { get; set; }
}