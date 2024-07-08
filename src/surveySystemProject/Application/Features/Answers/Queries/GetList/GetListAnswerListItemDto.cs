using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Answers.Queries.GetList;

public class GetListAnswerListItemDto : IDto
{
    public Guid Id { get; set; }
    public string UserAnswer { get; set; }
}