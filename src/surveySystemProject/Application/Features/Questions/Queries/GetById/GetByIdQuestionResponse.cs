using NArchitecture.Core.Application.Responses;

namespace Application.Features.Questions.Queries.GetById;

public class GetByIdQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string IndvQuestion { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}