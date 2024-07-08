using Application.Features.SurveyMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyMembers.Queries.GetById;

public class GetByIdSurveyMemberQuery : IRequest<GetByIdSurveyMemberResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSurveyMemberQueryHandler : IRequestHandler<GetByIdSurveyMemberQuery, GetByIdSurveyMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyMemberRepository _surveyMemberRepository;
        private readonly SurveyMemberBusinessRules _surveyMemberBusinessRules;

        public GetByIdSurveyMemberQueryHandler(IMapper mapper, ISurveyMemberRepository surveyMemberRepository, SurveyMemberBusinessRules surveyMemberBusinessRules)
        {
            _mapper = mapper;
            _surveyMemberRepository = surveyMemberRepository;
            _surveyMemberBusinessRules = surveyMemberBusinessRules;
        }

        public async Task<GetByIdSurveyMemberResponse> Handle(GetByIdSurveyMemberQuery request, CancellationToken cancellationToken)
        {
            SurveyMember? surveyMember = await _surveyMemberRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyMemberBusinessRules.SurveyMemberShouldExistWhenSelected(surveyMember);

            GetByIdSurveyMemberResponse response = _mapper.Map<GetByIdSurveyMemberResponse>(surveyMember);
            return response;
        }
    }
}