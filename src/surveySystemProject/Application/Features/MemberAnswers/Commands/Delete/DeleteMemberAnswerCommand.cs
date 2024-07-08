using Application.Features.MemberAnswers.Constants;
using Application.Features.MemberAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberAnswers.Commands.Delete;

public class DeleteMemberAnswerCommand : IRequest<DeletedMemberAnswerResponse>
{
    public Guid Id { get; set; }

    public class DeleteMemberAnswerCommandHandler : IRequestHandler<DeleteMemberAnswerCommand, DeletedMemberAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAnswerRepository _memberAnswerRepository;
        private readonly MemberAnswerBusinessRules _memberAnswerBusinessRules;

        public DeleteMemberAnswerCommandHandler(IMapper mapper, IMemberAnswerRepository memberAnswerRepository,
                                         MemberAnswerBusinessRules memberAnswerBusinessRules)
        {
            _mapper = mapper;
            _memberAnswerRepository = memberAnswerRepository;
            _memberAnswerBusinessRules = memberAnswerBusinessRules;
        }

        public async Task<DeletedMemberAnswerResponse> Handle(DeleteMemberAnswerCommand request, CancellationToken cancellationToken)
        {
            MemberAnswer? memberAnswer = await _memberAnswerRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAnswerBusinessRules.MemberAnswerShouldExistWhenSelected(memberAnswer);

            await _memberAnswerRepository.DeleteAsync(memberAnswer!);

            DeletedMemberAnswerResponse response = _mapper.Map<DeletedMemberAnswerResponse>(memberAnswer);
            return response;
        }
    }
}