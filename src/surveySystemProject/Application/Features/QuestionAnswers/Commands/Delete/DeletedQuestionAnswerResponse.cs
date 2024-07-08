using NArchitecture.Core.Application.Responses;

namespace Application.Features.QuestionAnswers.Commands.Delete;

public class DeletedQuestionAnswerResponse : IResponse
{
    public Guid Id { get; set; }
}