using Application.Features.SurveyAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SurveyAnswers.Commands.Create;

public class CreateSurveyAnswerCommand : IRequest<CreatedSurveyAnswerResponse>
{
    public required Guid SurveyId { get; set; }
    public required Guid AnswerId { get; set; }

    public class CreateSurveyAnswerCommandHandler : IRequestHandler<CreateSurveyAnswerCommand, CreatedSurveyAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyAnswerRepository _surveyAnswerRepository;
        private readonly SurveyAnswerBusinessRules _surveyAnswerBusinessRules;

        public CreateSurveyAnswerCommandHandler(IMapper mapper, ISurveyAnswerRepository surveyAnswerRepository,
                                         SurveyAnswerBusinessRules surveyAnswerBusinessRules)
        {
            _mapper = mapper;
            _surveyAnswerRepository = surveyAnswerRepository;
            _surveyAnswerBusinessRules = surveyAnswerBusinessRules;
        }

        public async Task<CreatedSurveyAnswerResponse> Handle(CreateSurveyAnswerCommand request, CancellationToken cancellationToken)
        {
            SurveyAnswer surveyAnswer = _mapper.Map<SurveyAnswer>(request);

            await _surveyAnswerRepository.AddAsync(surveyAnswer);

            CreatedSurveyAnswerResponse response = _mapper.Map<CreatedSurveyAnswerResponse>(surveyAnswer);
            return response;
        }
    }
}