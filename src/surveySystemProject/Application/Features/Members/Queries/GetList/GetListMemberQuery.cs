using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Members.Queries.GetList;

public class GetListMemberQuery : IRequest<GetListResponse<GetListMemberListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMemberQueryHandler : IRequestHandler<GetListMemberQuery, GetListResponse<GetListMemberListItemDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetListMemberQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberListItemDto>> Handle(GetListMemberQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Member> members = await _memberRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberListItemDto> response = _mapper.Map<GetListResponse<GetListMemberListItemDto>>(members);
            return response;
        }
    }
}