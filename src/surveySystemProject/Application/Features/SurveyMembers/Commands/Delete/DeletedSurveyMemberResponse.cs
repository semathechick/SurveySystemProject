using NArchitecture.Core.Application.Responses;

namespace Application.Features.SurveyMembers.Commands.Delete;

public class DeletedSurveyMemberResponse : IResponse
{
    public Guid Id { get; set; }
}