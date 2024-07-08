using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAnswerRepository : IAsyncRepository<Answer, Guid>, IRepository<Answer, Guid>
{
}