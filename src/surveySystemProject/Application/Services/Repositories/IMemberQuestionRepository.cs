using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberQuestionRepository : IAsyncRepository<MemberQuestion, Guid>, IRepository<MemberQuestion, Guid>
{
}