using Application.Features.SurveyMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyMembers.Commands.Create;

public class CreateSurveyMemberCommand : IRequest<CreatedSurveyMemberResponse>
{
    public required Guid MemberId { get; set; }
    public required Guid SurveyId { get; set; }

    public class CreateSurveyMemberCommandHandler : IRequestHandler<CreateSurveyMemberCommand, CreatedSurveyMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyMemberRepository _surveyMemberRepository;
        private readonly SurveyMemberBusinessRules _surveyMemberBusinessRules;

        public CreateSurveyMemberCommandHandler(IMapper mapper, ISurveyMemberRepository surveyMemberRepository,
                                         SurveyMemberBusinessRules surveyMemberBusinessRules)
        {
            _mapper = mapper;
            _surveyMemberRepository = surveyMemberRepository;
            _surveyMemberBusinessRules = surveyMemberBusinessRules;
        }

        public async Task<CreatedSurveyMemberResponse> Handle(CreateSurveyMemberCommand request, CancellationToken cancellationToken)
        {
            SurveyMember surveyMember = _mapper.Map<SurveyMember>(request);

            await _surveyMemberRepository.AddAsync(surveyMember);

            CreatedSurveyMemberResponse response = _mapper.Map<CreatedSurveyMemberResponse>(surveyMember);
            return response;
        }
    }
}