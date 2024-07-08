using Application.Features.MemberQuestions.Constants;
using Application.Features.MemberQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberQuestions.Commands.Delete;

public class DeleteMemberQuestionCommand : IRequest<DeletedMemberQuestionResponse>
{
    public Guid Id { get; set; }

    public class DeleteMemberQuestionCommandHandler : IRequestHandler<DeleteMemberQuestionCommand, DeletedMemberQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberQuestionRepository _memberQuestionRepository;
        private readonly MemberQuestionBusinessRules _memberQuestionBusinessRules;

        public DeleteMemberQuestionCommandHandler(IMapper mapper, IMemberQuestionRepository memberQuestionRepository,
                                         MemberQuestionBusinessRules memberQuestionBusinessRules)
        {
            _mapper = mapper;
            _memberQuestionRepository = memberQuestionRepository;
            _memberQuestionBusinessRules = memberQuestionBusinessRules;
        }

        public async Task<DeletedMemberQuestionResponse> Handle(DeleteMemberQuestionCommand request, CancellationToken cancellationToken)
        {
            MemberQuestion? memberQuestion = await _memberQuestionRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _memberQuestionBusinessRules.MemberQuestionShouldExistWhenSelected(memberQuestion);

            await _memberQuestionRepository.DeleteAsync(memberQuestion!);

            DeletedMemberQuestionResponse response = _mapper.Map<DeletedMemberQuestionResponse>(memberQuestion);
            return response;
        }
    }
}