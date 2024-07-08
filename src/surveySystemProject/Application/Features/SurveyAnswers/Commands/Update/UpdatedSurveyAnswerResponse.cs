using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyAnswers.Commands.Update;

public class UpdatedSurveyAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}