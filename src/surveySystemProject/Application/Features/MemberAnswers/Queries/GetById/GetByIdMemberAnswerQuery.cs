using Application.Features.MemberAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberAnswers.Queries.GetById;

public class GetByIdMemberAnswerQuery : IRequest<GetByIdMemberAnswerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdMemberAnswerQueryHandler : IRequestHandler<GetByIdMemberAnswerQuery, GetByIdMemberAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAnswerRepository _memberAnswerRepository;
        private readonly MemberAnswerBusinessRules _memberAnswerBusinessRules;

        public GetByIdMemberAnswerQueryHandler(IMapper mapper, IMemberAnswerRepository memberAnswerRepository, MemberAnswerBusinessRules memberAnswerBusinessRules)
        {
            _mapper = mapper;
            _memberAnswerRepository = memberAnswerRepository;
            _memberAnswerBusinessRules = memberAnswerBusinessRules;
        }

        public async Task<GetByIdMemberAnswerResponse> Handle(GetByIdMemberAnswerQuery request, CancellationToken cancellationToken)
        {
            MemberAnswer? memberAnswer = await _memberAnswerRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAnswerBusinessRules.MemberAnswerShouldExistWhenSelected(memberAnswer);

            GetByIdMemberAnswerResponse response = _mapper.Map<GetByIdMemberAnswerResponse>(memberAnswer);
            return response;
        }
    }
}