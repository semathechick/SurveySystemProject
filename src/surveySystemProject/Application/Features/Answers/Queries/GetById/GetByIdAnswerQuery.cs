using Application.Features.Answers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Answers.Queries.GetById;

public class GetByIdAnswerQuery : IRequest<GetByIdAnswerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAnswerQueryHandler : IRequestHandler<GetByIdAnswerQuery, GetByIdAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public GetByIdAnswerQueryHandler(IMapper mapper, IAnswerRepository answerRepository, AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<GetByIdAnswerResponse> Handle(GetByIdAnswerQuery request, CancellationToken cancellationToken)
        {
            Answer? answer = await _answerRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _answerBusinessRules.AnswerShouldExistWhenSelected(answer);

            GetByIdAnswerResponse response = _mapper.Map<GetByIdAnswerResponse>(answer);
            return response;
        }
    }
}