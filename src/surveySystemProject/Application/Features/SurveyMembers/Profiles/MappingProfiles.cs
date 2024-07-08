using Application.Features.SurveyMembers.Commands.Create;
using Application.Features.SurveyMembers.Commands.Delete;
using Application.Features.SurveyMembers.Commands.Update;
using Application.Features.SurveyMembers.Queries.GetById;
using Application.Features.SurveyMembers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SurveyMembers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSurveyMemberCommand, SurveyMember>();
        CreateMap<SurveyMember, CreatedSurveyMemberResponse>();

        CreateMap<UpdateSurveyMemberCommand, SurveyMember>();
        CreateMap<SurveyMember, UpdatedSurveyMemberResponse>();

        CreateMap<DeleteSurveyMemberCommand, SurveyMember>();
        CreateMap<SurveyMember, DeletedSurveyMemberResponse>();

        CreateMap<SurveyMember, GetByIdSurveyMemberResponse>();

        CreateMap<SurveyMember, GetListSurveyMemberListItemDto>();
        CreateMap<IPaginate<SurveyMember>, GetListResponse<GetListSurveyMemberListItemDto>>();
    }
}