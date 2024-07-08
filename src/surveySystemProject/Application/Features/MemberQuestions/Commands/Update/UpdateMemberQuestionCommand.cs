using Application.Features.MemberQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberQuestions.Commands.Update;

public class UpdateMemberQuestionCommand : IRequest<UpdatedMemberQuestionResponse>
{
    public Guid Id { get; set; }
    public required Guid MemberId { get; set; }
    public required Guid QuestionId { get; set; }

    public class UpdateMemberQuestionCommandHandler : IRequestHandler<UpdateMemberQuestionCommand, UpdatedMemberQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberQuestionRepository _memberQuestionRepository;
        private readonly MemberQuestionBusinessRules _memberQuestionBusinessRules;

        public UpdateMemberQuestionCommandHandler(IMapper mapper, IMemberQuestionRepository memberQuestionRepository,
                                         MemberQuestionBusinessRules memberQuestionBusinessRules)
        {
            _mapper = mapper;
            _memberQuestionRepository = memberQuestionRepository;
            _memberQuestionBusinessRules = memberQuestionBusinessRules;
        }

        public async Task<UpdatedMemberQuestionResponse> Handle(UpdateMemberQuestionCommand request, CancellationToken cancellationToken)
        {
            MemberQuestion? memberQuestion = await _memberQuestionRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _memberQuestionBusinessRules.MemberQuestionShouldExistWhenSelected(memberQuestion);
            memberQuestion = _mapper.Map(request, memberQuestion);

            await _memberQuestionRepository.UpdateAsync(memberQuestion!);

            UpdatedMemberQuestionResponse response = _mapper.Map<UpdatedMemberQuestionResponse>(memberQuestion);
            return response;
        }
    }
}