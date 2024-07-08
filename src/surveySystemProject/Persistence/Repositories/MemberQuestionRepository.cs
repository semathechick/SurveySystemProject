using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MemberQuestionRepository : EfRepositoryBase<MemberQuestion, Guid, BaseDbContext>, IMemberQuestionRepository
{
    public MemberQuestionRepository(BaseDbContext context) : base(context)
    {
    }
}