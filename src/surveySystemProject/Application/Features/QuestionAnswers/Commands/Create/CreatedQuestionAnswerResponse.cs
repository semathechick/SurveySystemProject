using NArchitecture.Core.Application.Responses;

namespace Application.Features.QuestionAnswers.Commands.Create;

public class CreatedQuestionAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}