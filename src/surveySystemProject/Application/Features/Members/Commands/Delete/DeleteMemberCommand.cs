using Application.Features.Members.Constants;
using Application.Features.Members.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Members.Commands.Delete;

public class DeleteMemberCommand : IRequest<DeletedMemberResponse>
{
    public Guid Id { get; set; }

    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, DeletedMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _memberRepository;
        private readonly MemberBusinessRules _memberBusinessRules;

        public DeleteMemberCommandHandler(IMapper mapper, IMemberRepository memberRepository,
                                         MemberBusinessRules memberBusinessRules)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;
            _memberBusinessRules = memberBusinessRules;
        }

        public async Task<DeletedMemberResponse> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _memberBusinessRules.MemberShouldExistWhenSelected(member);

            await _memberRepository.DeleteAsync(member!);

            DeletedMemberResponse response = _mapper.Map<DeletedMemberResponse>(member);
            return response;
        }
    }
}