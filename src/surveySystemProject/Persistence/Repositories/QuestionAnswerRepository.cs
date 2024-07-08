using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionAnswerRepository : EfRepositoryBase<QuestionAnswer, Guid, BaseDbContext>, IQuestionAnswerRepository
{
    public QuestionAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}