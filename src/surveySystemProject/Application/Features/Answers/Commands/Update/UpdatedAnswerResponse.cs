using NArchitecture.Core.Application.Responses;

namespace Application.Features.Answers.Commands.Update;

public class UpdatedAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserAnswer { get; set; }
}