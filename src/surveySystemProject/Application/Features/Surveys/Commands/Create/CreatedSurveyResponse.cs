using NArchitecture.Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Create;

public class CreatedSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public string SurveyTitle { get; set; }
}