using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyAnswers.Queries.GetById;

public class GetByIdSurveyAnswerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}