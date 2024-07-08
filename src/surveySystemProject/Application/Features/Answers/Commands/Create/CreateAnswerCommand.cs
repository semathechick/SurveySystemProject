using Application.Features.Answers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Answers.Commands.Create;

public class CreateAnswerCommand : IRequest<CreatedAnswerResponse>
{
    public required string UserAnswer { get; set; }
    public required Guid QuestionId { get; set; }

    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreatedAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public CreateAnswerCommandHandler(IMapper mapper, IAnswerRepository answerRepository,
                                         AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<CreatedAnswerResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            Answer answer = _mapper.Map<Answer>(request);

            await _answerRepository.AddAsync(answer);

            CreatedAnswerResponse response = _mapper.Map<CreatedAnswerResponse>(answer);
            return response;
        }
    }
}