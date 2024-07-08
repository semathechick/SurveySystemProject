using NArchitecture.Core.Application.Responses;

namespace Application.Features.QuestionAnswers.Commands.Update;

public class UpdatedQuestionAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}