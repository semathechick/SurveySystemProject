using Application.Features.SurveyAnswers.Constants;
using Application.Features.SurveyAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyAnswers.Commands.Delete;

public class DeleteSurveyAnswerCommand : IRequest<DeletedSurveyAnswerResponse>
{
    public Guid Id { get; set; }

    public class DeleteSurveyAnswerCommandHandler : IRequestHandler<DeleteSurveyAnswerCommand, DeletedSurveyAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly SurveyAnswerBusinessRules _surveyAnswerBusinessRules;

        public DeleteSurveyAnswerCommandHandler(IMapper mapper, ISurveyAnswerRepository surveyAnswerRepository,
                                         SurveyAnswerBusinessRules surveyAnswerBusinessRules)
        {
            _mapper = mapper;
            _surveyAnswerRepository = surveyAnswerRepository;
            _surveyAnswerBusinessRules = surveyAnswerBusinessRules;
        }

        public async Task<DeletedSurveyAnswerResponse> Handle(DeleteSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            SurveyAnswer? surveyAnswer = await _surveyAnswerRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyAnswerBusinessRules.SurveyAnswerShouldExistWhenSelected(surveyAnswer);

            await _surveyAnswerRepository.DeleteAsync(surveyAnswer!);

            DeletedSurveyAnswerResponse response = _mapper.Map<DeletedSurveyAnswerResponse>(surveyAnswer);
            return response;
        }
    }
}