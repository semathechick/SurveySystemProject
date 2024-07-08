using Application.Features.SurveyAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyAnswers.Queries.GetById;

public class GetByIdSurveyAnswerQuery : IRequest<GetByIdSurveyAnswerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSurveyAnswerQueryHandler : IRequestHandler<GetByIdSurveyAnswerQuery, GetByIdSurveyAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly SurveyAnswerBusinessRules _surveyAnswerBusinessRules;

        public GetByIdSurveyAnswerQueryHandler(IMapper mapper, ISurveyAnswerRepository surveyAnswerRepository, SurveyAnswerBusinessRules surveyAnswerBusinessRules)
        {
            _mapper = mapper;
            _surveyAnswerRepository = surveyAnswerRepository;
            _surveyAnswerBusinessRules = surveyAnswerBusinessRules;
        }

        public async Task<GetByIdSurveyAnswerResponse> Handle(GetByIdSurveyAnswerQuery request, CancellationToken cancellationToken)
        {
            SurveyAnswer? surveyAnswer = await _surveyAnswerRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyAnswerBusinessRules.SurveyAnswerShouldExistWhenSelected(surveyAnswer);

            GetByIdSurveyAnswerResponse response = _mapper.Map<GetByIdSurveyAnswerResponse>(surveyAnswer);
            return response;
        }
    }
}