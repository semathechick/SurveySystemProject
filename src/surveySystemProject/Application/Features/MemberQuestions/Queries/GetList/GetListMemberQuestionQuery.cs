using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.MemberQuestions.Queries.GetList;

public class GetListMemberQuestionQuery : IRequest<GetListResponse<GetListMemberQuestionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListMemberQuestionQueryHandler : IRequestHandler<GetListMemberQuestionQuery, GetListResponse<GetListMemberQuestionListItemDto>>
    {
        private readonly IMemberQuestionRepository _memberQuestionRepository;
        private readonly IMapper _mapper;

        public GetListMemberQuestionQueryHandler(IMemberQuestionRepository memberQuestionRepository, IMapper mapper)
        {
            _memberQuestionRepository = memberQuestionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMemberQuestionListItemDto>> Handle(GetListMemberQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MemberQuestion> memberQuestions = await _memberQuestionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMemberQuestionListItemDto> response = _mapper.Map<GetListResponse<GetListMemberQuestionListItemDto>>(memberQuestions);
            return response;
        }
    }
}