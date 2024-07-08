using Application.Features.SurveyAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyAnswers.Commands.Update;

public class UpdateSurveyAnswerCommand : IRequest<UpdatedSurveyAnswerResponse>
{
    public Guid Id { get; set; }
    public required Guid SurveyId { get; set; }
    public required Guid AnswerId { get; set; }

    public class UpdateSurveyAnswerCommandHandler : IRequestHandler<UpdateSurveyAnswerCommand, UpdatedSurveyAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly SurveyAnswerBusinessRules _surveyAnswerBusinessRules;

        public UpdateSurveyAnswerCommandHandler(IMapper mapper, ISurveyAnswerRepository surveyAnswerRepository,
                                         SurveyAnswerBusinessRules surveyAnswerBusinessRules)
        {
            _mapper = mapper;
            _surveyAnswerRepository = surveyAnswerRepository;
            _surveyAnswerBusinessRules = surveyAnswerBusinessRules;
        }

        public async Task<UpdatedSurveyAnswerResponse> Handle(UpdateSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            SurveyAnswer? surveyAnswer = await _surveyAnswerRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyAnswerBusinessRules.SurveyAnswerShouldExistWhenSelected(surveyAnswer);
            surveyAnswer = _mapper.Map(request, surveyAnswer);

            await _surveyAnswerRepository.UpdateAsync(surveyAnswer!);

            UpdatedSurveyAnswerResponse response = _mapper.Map<UpdatedSurveyAnswerResponse>(surveyAnswer);
            return response;
        }
    }
}