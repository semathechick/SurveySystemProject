using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Questions.Commands.Update;

public class UpdatedQuestionResponse : IResponse
{
    public Guid Id { get; set; }
    public string IndvQuestion { get; set; }
    public Survey? Survey { get; set; }
    public Guid SurveyId { get; set; }
    public Guid AnswerId { get; set; }
}