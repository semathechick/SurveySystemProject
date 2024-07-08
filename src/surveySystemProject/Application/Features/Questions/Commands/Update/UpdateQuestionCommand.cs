using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Questions.Commands.Update;

public class UpdateQuestionCommand : IRequest<UpdatedQuestionResponse>
{
    public Guid Id { get; set; }
    public required string IndvQuestion { get; set; }
    public Survey? Survey { get; set; }
    public required Guid SurveyId { get; set; }
    public required Guid AnswerId { get; set; }

    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, UpdatedQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public UpdateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository,
                                         QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<UpdatedQuestionResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question? question = await _questionRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _questionBusinessRules.QuestionShouldExistWhenSelected(question);
            question = _mapper.Map(request, question);

            await _questionRepository.UpdateAsync(question!);

            UpdatedQuestionResponse response = _mapper.Map<UpdatedQuestionResponse>(question);
            return response;
        }
    }
}