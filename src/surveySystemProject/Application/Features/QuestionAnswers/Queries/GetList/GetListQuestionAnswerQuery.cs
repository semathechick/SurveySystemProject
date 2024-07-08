using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.QuestionAnswers.Queries.GetList;

public class GetListQuestionAnswerQuery : IRequest<GetListResponse<GetListQuestionAnswerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListQuestionAnswerQueryHandler : IRequestHandler<GetListQuestionAnswerQuery, GetListResponse<GetListQuestionAnswerListItemDto>>
    {
        private readonly IQuestionAnswerRepository _questionAnswerRepository;
        private readonly IMapper _mapper;

        public GetListQuestionAnswerQueryHandler(IQuestionAnswerRepository questionAnswerRepository, IMapper mapper)
        {
            _questionAnswerRepository = questionAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionAnswerListItemDto>> Handle(GetListQuestionAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<QuestionAnswer> questionAnswers = await _questionAnswerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuestionAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListQuestionAnswerListItemDto>>(questionAnswers);
            return response;
        }
    }
}