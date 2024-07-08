using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyMemberRepository : EfRepositoryBase<SurveyMember, Guid, BaseDbContext>, ISurveyMemberRepository
{
    public SurveyMemberRepository(BaseDbContext context) : base(context)
    {
    }
}