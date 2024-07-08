using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.MemberAnswers.Queries.GetList;

public class GetListMemberAnswerQuery : IRequest<GetListResponse<GetListMemberAnswerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMemberAnswerQueryHandler : IRequestHandler<GetListMemberAnswerQuery, GetListResponse<GetListMemberAnswerListItemDto>>
    {
        private readonly IMemberAnswerRepository _memberAnswerRepository;
        private readonly IMapper _mapper;

        public GetListMemberAnswerQueryHandler(IMemberAnswerRepository memberAnswerRepository, IMapper mapper)
        {
            _memberAnswerRepository = memberAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberAnswerListItemDto>> Handle(GetListMemberAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MemberAnswer> memberAnswers = await _memberAnswerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListMemberAnswerListItemDto>>(memberAnswers);
            return response;
        }
    }
}