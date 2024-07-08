using NArchitecture.Core.Application.Dtos;

namespace Application.Features.QuestionAnswers.Queries.GetList;

public class GetListQuestionAnswerListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}