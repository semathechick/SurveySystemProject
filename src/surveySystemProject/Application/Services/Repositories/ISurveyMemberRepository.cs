using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISurveyMemberRepository : IAsyncRepository<SurveyMember, Guid>, IRepository<SurveyMember, Guid>
{
}