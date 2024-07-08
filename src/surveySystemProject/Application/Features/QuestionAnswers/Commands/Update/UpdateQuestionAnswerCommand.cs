using Application.Features.QuestionAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionAnswers.Commands.Update;

public class UpdateQuestionAnswerCommand : IRequest<UpdatedQuestionAnswerResponse>
{
    public Guid Id { get; set; }
    public required Guid QuestionId { get; set; }
    public required Guid AnswerId { get; set; }

    public class UpdateQuestionAnswerCommandHandler : IRequestHandler<UpdateQuestionAnswerCommand, UpdatedQuestionAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly QuestionAnswerBusinessRules _questionAnswerBusinessRules;

        public UpdateQuestionAnswerCommandHandler(IMapper mapper, IQuestionAnswerRepository questionAnswerRepository,
                                         QuestionAnswerBusinessRules questionAnswerBusinessRules)
        {
            _mapper = mapper;
            _questionAnswerRepository = questionAnswerRepository;
            _questionAnswerBusinessRules = questionAnswerBusinessRules;
        }

        public async Task<UpdatedQuestionAnswerResponse> Handle(UpdateQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            QuestionAnswer? questionAnswer = await _questionAnswerRepository.GetAsync(predicate: qa => qa.Id == request.Id, cancellationToken: cancellationToken);
            await _questionAnswerBusinessRules.QuestionAnswerShouldExistWhenSelected(questionAnswer);
            questionAnswer = _mapper.Map(request, questionAnswer);

            await _questionAnswerRepository.UpdateAsync(questionAnswer!);

            UpdatedQuestionAnswerResponse response = _mapper.Map<UpdatedQuestionAnswerResponse>(questionAnswer);
            return response;
        }
    }
}