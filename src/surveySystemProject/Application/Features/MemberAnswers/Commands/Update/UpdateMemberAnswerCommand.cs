using Application.Features.MemberAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberAnswers.Commands.Update;

public class UpdateMemberAnswerCommand : IRequest<UpdatedMemberAnswerResponse>
{
    public Guid Id { get; set; }
    public required Guid MemberId { get; set; }
    public required Guid AnswerId { get; set; }

    public class UpdateMemberAnswerCommandHandler : IRequestHandler<UpdateMemberAnswerCommand, UpdatedMemberAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAnswerRepository _memberAnswerRepository;
        private readonly MemberAnswerBusinessRules _memberAnswerBusinessRules;

        public UpdateMemberAnswerCommandHandler(IMapper mapper, IMemberAnswerRepository memberAnswerRepository,
                                         MemberAnswerBusinessRules memberAnswerBusinessRules)
        {
            _mapper = mapper;
            _memberAnswerRepository = memberAnswerRepository;
            _memberAnswerBusinessRules = memberAnswerBusinessRules;
        }

        public async Task<UpdatedMemberAnswerResponse> Handle(UpdateMemberAnswerCommand request, CancellationToken cancellationToken)
        {
            MemberAnswer? memberAnswer = await _memberAnswerRepository.GetAsync(predicate: ma => ma.Id == request.Id, cancellationToken: cancellationToken);
            await _memberAnswerBusinessRules.MemberAnswerShouldExistWhenSelected(memberAnswer);
            memberAnswer = _mapper.Map(request, memberAnswer);

            await _memberAnswerRepository.UpdateAsync(memberAnswer!);

            UpdatedMemberAnswerResponse response = _mapper.Map<UpdatedMemberAnswerResponse>(memberAnswer);
            return response;
        }
    }
}