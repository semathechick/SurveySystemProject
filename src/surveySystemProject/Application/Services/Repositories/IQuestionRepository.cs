using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IQuestionRepository : IAsyncRepository<Question, Guid>, IRepository<Question, Guid>
{
}