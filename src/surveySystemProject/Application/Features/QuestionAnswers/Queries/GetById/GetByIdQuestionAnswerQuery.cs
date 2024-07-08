using Application.Features.QuestionAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuestionAnswers.Queries.GetById;

public class GetByIdQuestionAnswerQuery : IRequest<GetByIdQuestionAnswerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdQuestionAnswerQueryHandler : IRequestHandler<GetByIdQuestionAnswerQuery, GetByIdQuestionAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly QuestionAnswerBusinessRules _questionAnswerBusinessRules;

        public GetByIdQuestionAnswerQueryHandler(IMapper mapper, IQuestionAnswerRepository questionAnswerRepository, QuestionAnswerBusinessRules questionAnswerBusinessRules)
        {
            _mapper = mapper;
            _questionAnswerRepository = questionAnswerRepository;
            _questionAnswerBusinessRules = questionAnswerBusinessRules;
        }

        public async Task<GetByIdQuestionAnswerResponse> Handle(GetByIdQuestionAnswerQuery request, CancellationToken cancellationToken)
        {
            QuestionAnswer? questionAnswer = await _questionAnswerRepository.GetAsync(predicate: qa => qa.Id == request.Id, cancellationToken: cancellationToken);
            await _questionAnswerBusinessRules.QuestionAnswerShouldExistWhenSelected(questionAnswer);

            GetByIdQuestionAnswerResponse response = _mapper.Map<GetByIdQuestionAnswerResponse>(questionAnswer);
            return response;
        }
    }
}