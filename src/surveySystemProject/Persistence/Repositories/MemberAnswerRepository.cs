using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberAnswerRepository : EfRepositoryBase<MemberAnswer, Guid, BaseDbContext>, IMemberAnswerRepository
{
    public MemberAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}