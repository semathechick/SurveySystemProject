using Application.Features.MemberAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberAnswers.Commands.Create;

public class CreateMemberAnswerCommand : IRequest<CreatedMemberAnswerResponse>
{
    public required Guid MemberId { get; set; }
    public required Guid AnswerId { get; set; }

    public class CreateMemberAnswerCommandHandler : IRequestHandler<CreateMemberAnswerCommand, CreatedMemberAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberAnswerRepository _memberAnswerRepository;
        private readonly MemberAnswerBusinessRules _memberAnswerBusinessRules;

        public CreateMemberAnswerCommandHandler(IMapper mapper, IMemberAnswerRepository memberAnswerRepository,
                                         MemberAnswerBusinessRules memberAnswerBusinessRules)
        {
            _mapper = mapper;
            _memberAnswerRepository = memberAnswerRepository;
            _memberAnswerBusinessRules = memberAnswerBusinessRules;
        }

        public async Task<CreatedMemberAnswerResponse> Handle(CreateMemberAnswerCommand request, CancellationToken cancellationToken)
        {
            MemberAnswer memberAnswer = _mapper.Map<MemberAnswer>(request);

            await _memberAnswerRepository.AddAsync(memberAnswer);

            CreatedMemberAnswerResponse response = _mapper.Map<CreatedMemberAnswerResponse>(memberAnswer);
            return response;
        }
    }
}