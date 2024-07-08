using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SurveyAnswers.Queries.GetList;

public class GetListSurveyAnswerListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}