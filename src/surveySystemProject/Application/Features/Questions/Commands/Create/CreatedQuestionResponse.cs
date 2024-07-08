using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Questions.Commands.Create;

public class CreatedQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string IndvQuestion { get; set; }
    public Survey? Survey { get; set; }
    public Guid SurveyId { get; set; }
}