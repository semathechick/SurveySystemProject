using Application.Features.Answers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Answers.Commands.Update;

public class UpdateAnswerCommand : IRequest<UpdatedAnswerResponse>
{
    public Guid Id { get; set; }
    public required string UserAnswer { get; set; }

    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, UpdatedAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public UpdateAnswerCommandHandler(IMapper mapper, IAnswerRepository answerRepository,
                                         AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<UpdatedAnswerResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            Answer? answer = await _answerRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _answerBusinessRules.AnswerShouldExistWhenSelected(answer);
            answer = _mapper.Map(request, answer);

            await _answerRepository.UpdateAsync(answer!);

            UpdatedAnswerResponse response = _mapper.Map<UpdatedAnswerResponse>(answer);
            return response;
        }
    }
}