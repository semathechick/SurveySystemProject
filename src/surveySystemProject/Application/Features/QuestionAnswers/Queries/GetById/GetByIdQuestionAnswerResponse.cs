using NArchitecture.Core.Application.Responses;

namespace Application.Features.QuestionAnswers.Queries.GetById;

public class GetByIdQuestionAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}