using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Answers.Queries.GetList;

public class GetListAnswerQuery : IRequest<GetListResponse<GetListAnswerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAnswerQueryHandler : IRequestHandler<GetListAnswerQuery, GetListResponse<GetListAnswerListItemDto>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetListAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAnswerListItemDto>> Handle(GetListAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Answer> answers = await _answerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListAnswerListItemDto>>(answers);
            return response;
        }
    }
}