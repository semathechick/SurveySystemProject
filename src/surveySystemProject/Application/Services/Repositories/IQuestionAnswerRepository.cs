using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IQuestionAnswerRepository : IAsyncRepository<QuestionAnswer, Guid>, IRepository<QuestionAnswer, Guid>
{
}