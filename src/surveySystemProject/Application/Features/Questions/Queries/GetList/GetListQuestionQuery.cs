using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionQuery : IRequest<GetListResponse<GetListQuestionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, GetListResponse<GetListQuestionListItemDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionListItemDto>> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Question> questions = await _questionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuestionListItemDto> response = _mapper.Map<GetListResponse<GetListQuestionListItemDto>>(questions);
            return response;
        }
    }
}