using Application.Features.QuestionAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionAnswers.Commands.Create;

public class CreateQuestionAnswerCommand : IRequest<CreatedQuestionAnswerResponse>
{
    public required Guid QuestionId { get; set; }
    public required Guid AnswerId { get; set; }

    public class CreateQuestionAnswerCommandHandler : IRequestHandler<CreateQuestionAnswerCommand, CreatedQuestionAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly QuestionAnswerBusinessRules _questionAnswerBusinessRules;

        public CreateQuestionAnswerCommandHandler(IMapper mapper, IQuestionAnswerRepository questionAnswerRepository,
                                         QuestionAnswerBusinessRules questionAnswerBusinessRules)
        {
            _mapper = mapper;
            _questionAnswerRepository = questionAnswerRepository;
            _questionAnswerBusinessRules = questionAnswerBusinessRules;
        }

        public async Task<CreatedQuestionAnswerResponse> Handle(CreateQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            QuestionAnswer questionAnswer = _mapper.Map<QuestionAnswer>(request);

            await _questionAnswerRepository.AddAsync(questionAnswer);

            CreatedQuestionAnswerResponse response = _mapper.Map<CreatedQuestionAnswerResponse>(questionAnswer);
            return response;
        }
    }
}