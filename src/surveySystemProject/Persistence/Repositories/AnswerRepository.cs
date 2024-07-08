using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnswerRepository : EfRepositoryBase<Answer, Guid, BaseDbContext>, IAnswerRepository
{
    public AnswerRepository(BaseDbContext context) : base(context)
    {
    }
}