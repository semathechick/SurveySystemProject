using NArchitecture.Core.Application.Responses;

namespace Application.Features.Answers.Queries.GetById;

public class GetByIdAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserAnswer { get; set; }
}