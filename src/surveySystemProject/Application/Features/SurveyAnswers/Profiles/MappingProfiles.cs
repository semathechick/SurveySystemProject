using Application.Features.SurveyAnswers.Commands.Create;
using Application.Features.SurveyAnswers.Commands.Delete;
using Application.Features.SurveyAnswers.Commands.Update;
using Application.Features.SurveyAnswers.Queries.GetById;
using Application.Features.SurveyAnswers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SurveyAnswers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSurveyAnswerCommand, SurveyAnswer>();
        CreateMap<SurveyAnswer, CreatedSurveyAnswerResponse>();

        CreateMap<UpdateSurveyAnswerCommand, SurveyAnswer>();
        CreateMap<SurveyAnswer, UpdatedSurveyAnswerResponse>();

        CreateMap<DeleteSurveyAnswerCommand, SurveyAnswer>();
        CreateMap<SurveyAnswer, DeletedSurveyAnswerResponse>();

        CreateMap<SurveyAnswer, GetByIdSurveyAnswerResponse>();

        CreateMap<SurveyAnswer, GetListSurveyAnswerListItemDto>();
        CreateMap<IPaginate<SurveyAnswer>, GetListResponse<GetListSurveyAnswerListItemDto>>();
    }
}