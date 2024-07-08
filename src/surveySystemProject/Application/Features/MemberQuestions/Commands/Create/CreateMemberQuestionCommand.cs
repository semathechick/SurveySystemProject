using Application.Features.MemberQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberQuestions.Commands.Create;

public class CreateMemberQuestionCommand : IRequest<CreatedMemberQuestionResponse>
{
    public required Guid MemberId { get; set; }
    public required Guid QuestionId { get; set; }

    public class CreateMemberQuestionCommandHandler : IRequestHandler<CreateMemberQuestionCommand, CreatedMemberQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberQuestionRepository _memberQuestionRepository;
        private readonly MemberQuestionBusinessRules _memberQuestionBusinessRules;

        public CreateMemberQuestionCommandHandler(IMapper mapper, IMemberQuestionRepository memberQuestionRepository,
                                         MemberQuestionBusinessRules memberQuestionBusinessRules)
        {
            _mapper = mapper;
            _memberQuestionRepository = memberQuestionRepository;
            _memberQuestionBusinessRules = memberQuestionBusinessRules;
        }

        public async Task<CreatedMemberQuestionResponse> Handle(CreateMemberQuestionCommand request, CancellationToken cancellationToken)
        {
            MemberQuestion memberQuestion = _mapper.Map<MemberQuestion>(request);

            await _memberQuestionRepository.AddAsync(memberQuestion);

            CreatedMemberQuestionResponse response = _mapper.Map<CreatedMemberQuestionResponse>(memberQuestion);
            return response;
        }
    }
}