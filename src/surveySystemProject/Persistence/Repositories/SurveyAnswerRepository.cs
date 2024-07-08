using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyAnswerRepository : EfRepositoryBase<SurveyAnswer, Guid, BaseDbContext>, ISurveyAnswerRepository
{
    public SurveyAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}