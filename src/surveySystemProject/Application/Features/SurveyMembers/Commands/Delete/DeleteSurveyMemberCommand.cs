using Application.Features.SurveyMembers.Constants;
using Application.Features.SurveyMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyMembers.Commands.Delete;

public class DeleteSurveyMemberCommand : IRequest<DeletedSurveyMemberResponse>
{
    public Guid Id { get; set; }

    public class DeleteSurveyMemberCommandHandler : IRequestHandler<DeleteSurveyMemberCommand, DeletedSurveyMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyMemberRepository _surveyMemberRepository;
        private readonly SurveyMemberBusinessRules _surveyMemberBusinessRules;

        public DeleteSurveyMemberCommandHandler(IMapper mapper, ISurveyMemberRepository surveyMemberRepository,
                                         SurveyMemberBusinessRules surveyMemberBusinessRules)
        {
            _mapper = mapper;
            _surveyMemberRepository = surveyMemberRepository;
            _surveyMemberBusinessRules = surveyMemberBusinessRules;
        }

        public async Task<DeletedSurveyMemberResponse> Handle(DeleteSurveyMemberCommand request, CancellationToken cancellationToken)
        {
            SurveyMember? surveyMember = await _surveyMemberRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyMemberBusinessRules.SurveyMemberShouldExistWhenSelected(surveyMember);

            await _surveyMemberRepository.DeleteAsync(surveyMember!);

            DeletedSurveyMemberResponse response = _mapper.Map<DeletedSurveyMemberResponse>(surveyMember);
            return response;
        }
    }
}