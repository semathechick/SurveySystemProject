using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string IndvQuestion { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}