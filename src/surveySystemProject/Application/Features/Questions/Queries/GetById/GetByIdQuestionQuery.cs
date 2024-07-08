using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Questions.Queries.GetById;

public class GetByIdQuestionQuery : IRequest<GetByIdQuestionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQuery, GetByIdQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public GetByIdQuestionQueryHandler(IMapper mapper, IQuestionRepository questionRepository, QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<GetByIdQuestionResponse> Handle(GetByIdQuestionQuery request, CancellationToken cancellationToken)
        {
            Question? question = await _questionRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _questionBusinessRules.QuestionShouldExistWhenSelected(question);

            GetByIdQuestionResponse response = _mapper.Map<GetByIdQuestionResponse>(question);
            return response;
        }
    }
}