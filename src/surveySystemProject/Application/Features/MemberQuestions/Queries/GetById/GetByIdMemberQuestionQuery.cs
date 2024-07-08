using Application.Features.MemberQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.MemberQuestions.Queries.GetById;

public class GetByIdMemberQuestionQuery : IRequest<GetByIdMemberQuestionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdMemberQuestionQueryHandler : IRequestHandler<GetByIdMemberQuestionQuery, GetByIdMemberQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMemberQuestionRepository _memberQuestionRepository;
        private readonly MemberQuestionBusinessRules _memberQuestionBusinessRules;

        public GetByIdMemberQuestionQueryHandler(IMapper mapper, IMemberQuestionRepository memberQuestionRepository, MemberQuestionBusinessRules memberQuestionBusinessRules)
        {
            _mapper = mapper;
            _memberQuestionRepository = memberQuestionRepository;
            _memberQuestionBusinessRules = memberQuestionBusinessRules;
        }

        public async Task<GetByIdMemberQuestionResponse> Handle(GetByIdMemberQuestionQuery request, CancellationToken cancellationToken)
        {
            MemberQuestion? memberQuestion = await _memberQuestionRepository.GetAsync(predicate: mq => mq.Id == request.Id, cancellationToken: cancellationToken);
            await _memberQuestionBusinessRules.MemberQuestionShouldExistWhenSelected(memberQuestion);

            GetByIdMemberQuestionResponse response = _mapper.Map<GetByIdMemberQuestionResponse>(memberQuestion);
            return response;
        }
    }
}