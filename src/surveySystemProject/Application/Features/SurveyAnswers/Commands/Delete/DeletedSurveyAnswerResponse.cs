using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyAnswers.Commands.Delete;

public class DeletedSurveyAnswerResponse : IResponse
{
    public Guid Id { get; set; }
}