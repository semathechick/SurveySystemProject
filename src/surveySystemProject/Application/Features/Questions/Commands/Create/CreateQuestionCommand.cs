using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommand : IRequest<CreatedQuestionResponse>
{
    public required string IndvQuestion { get; set; }
    //public Survey? Survey { get; set; }
    public required Guid SurveyId { get; set; }
    //public required Guid AnswerId { get; set; }

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreatedQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public CreateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository,
                                         QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<CreatedQuestionResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question question = _mapper.Map<Question>(request);

            await _questionRepository.AddAsync(question);

            CreatedQuestionResponse response = _mapper.Map<CreatedQuestionResponse>(question);
            return response;
        }
    }
}