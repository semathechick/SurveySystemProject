using Application.Features.QuestionAnswers.Constants;
using Application.Features.QuestionAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionAnswers.Commands.Delete;

public class DeleteQuestionAnswerCommand : IRequest<DeletedQuestionAnswerResponse>
{
    public Guid Id { get; set; }

    public class DeleteQuestionAnswerCommandHandler : IRequestHandler<DeleteQuestionAnswerCommand, DeletedQuestionAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly QuestionAnswerBusinessRules _questionAnswerBusinessRules;

        public DeleteQuestionAnswerCommandHandler(IMapper mapper, IQuestionAnswerRepository questionAnswerRepository,
                                         QuestionAnswerBusinessRules questionAnswerBusinessRules)
        {
            _mapper = mapper;
            _questionAnswerRepository = questionAnswerRepository;
            _questionAnswerBusinessRules = questionAnswerBusinessRules;
        }

        public async Task<DeletedQuestionAnswerResponse> Handle(DeleteQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            QuestionAnswer? questionAnswer = await _questionAnswerRepository.GetAsync(predicate: qa => qa.Id == request.Id, cancellationToken: cancellationToken);
            await _questionAnswerBusinessRules.QuestionAnswerShouldExistWhenSelected(questionAnswer);

            await _questionAnswerRepository.DeleteAsync(questionAnswer!);

            DeletedQuestionAnswerResponse response = _mapper.Map<DeletedQuestionAnswerResponse>(questionAnswer);
            return response;
        }
    }
}