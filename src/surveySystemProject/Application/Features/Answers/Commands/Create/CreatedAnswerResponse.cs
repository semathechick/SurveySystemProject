using NArchitecture.Core.Application.Responses;

namespace Application.Features.Answers.Commands.Create;

public class CreatedAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserAnswer { get; set; }
}