using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMemberAnswerRepository : IAsyncRepository<MemberAnswer, Guid>, IRepository<MemberAnswer, Guid>
{
}