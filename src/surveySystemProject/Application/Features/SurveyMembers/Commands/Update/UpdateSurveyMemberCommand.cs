using Application.Features.SurveyMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyMembers.Commands.Update;

public class UpdateSurveyMemberCommand : IRequest<UpdatedSurveyMemberResponse>
{
    public Guid Id { get; set; }
    public required Guid MemberId { get; set; }
    public required Guid SurveyId { get; set; }

    public class UpdateSurveyMemberCommandHandler : IRequestHandler<UpdateSurveyMemberCommand, UpdatedSurveyMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyMemberRepository _surveyMemberRepository;
        private readonly SurveyMemberBusinessRules _surveyMemberBusinessRules;

        public UpdateSurveyMemberCommandHandler(IMapper mapper, ISurveyMemberRepository surveyMemberRepository,
                                         SurveyMemberBusinessRules surveyMemberBusinessRules)
        {
            _mapper = mapper;
            _surveyMemberRepository = surveyMemberRepository;
            _surveyMemberBusinessRules = surveyMemberBusinessRules;
        }

        public async Task<UpdatedSurveyMemberResponse> Handle(UpdateSurveyMemberCommand request, CancellationToken cancellationToken)
        {
            SurveyMember? surveyMember = await _surveyMemberRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyMemberBusinessRules.SurveyMemberShouldExistWhenSelected(surveyMember);
            surveyMember = _mapper.Map(request, surveyMember);

            await _surveyMemberRepository.UpdateAsync(surveyMember!);

            UpdatedSurveyMemberResponse response = _mapper.Map<UpdatedSurveyMemberResponse>(surveyMember);
            return response;
        }
    }
}