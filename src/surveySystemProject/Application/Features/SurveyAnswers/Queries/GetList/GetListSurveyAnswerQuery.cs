using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SurveyAnswers.Queries.GetList;

public class GetListSurveyAnswerQuery : IRequest<GetListResponse<GetListSurveyAnswerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSurveyAnswerQueryHandler : IRequestHandler<GetListSurveyAnswerQuery, GetListResponse<GetListSurveyAnswerListItemDto>>
    {
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly IMapper _mapper;

        public GetListSurveyAnswerQueryHandler(ISurveyAnswerRepository surveyAnswerRepository, IMapper mapper)
        {
            _surveyAnswerRepository = surveyAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSurveyAnswerListItemDto>> Handle(GetListSurveyAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SurveyAnswer> surveyAnswers = await _surveyAnswerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSurveyAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListSurveyAnswerListItemDto>>(surveyAnswers);
            return response;
        }
    }
}