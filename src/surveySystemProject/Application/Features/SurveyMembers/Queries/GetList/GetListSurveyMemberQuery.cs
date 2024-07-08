using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SurveyMembers.Queries.GetList;

public class GetListSurveyMemberQuery : IRequest<GetListResponse<GetListSurveyMemberListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSurveyMemberQueryHandler : IRequestHandler<GetListSurveyMemberQuery, GetListResponse<GetListSurveyMemberListItemDto>>
    {
        private readonly ISurveyMemberRepository _surveyMemberRepository;
        private readonly IMapper _mapper;

        public GetListSurveyMemberQueryHandler(ISurveyMemberRepository surveyMemberRepository, IMapper mapper)
        {
            _surveyMemberRepository = surveyMemberRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSurveyMemberListItemDto>> Handle(GetListSurveyMemberQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SurveyMember> surveyMembers = await _surveyMemberRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSurveyMemberListItemDto> response = _mapper.Map<GetListResponse<GetListSurveyMemberListItemDto>>(surveyMembers);
            return response;
        }
    }
}