using Application.Features.Surveys.Commands.Create;
using Application.Features.Surveys.Commands.Delete;
using Application.Features.Surveys.Commands.Update;
using Application.Features.Surveys.Queries.GetById;
using Application.Features.Surveys.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Surveys.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSurveyCommand, Survey>();
        CreateMap<Survey, CreatedSurveyResponse>();

        CreateMap<UpdateSurveyCommand, Survey>();
        CreateMap<Survey, UpdatedSurveyResponse>();

        CreateMap<DeleteSurveyCommand, Survey>();
        CreateMap<Survey, DeletedSurveyResponse>();

        CreateMap<Survey, GetByIdSurveyResponse>();

        CreateMap<Survey, GetListSurveyListItemDto>();
        CreateMap<IPaginate<Survey>, GetListResponse<GetListSurveyListItemDto>>();
    }
}