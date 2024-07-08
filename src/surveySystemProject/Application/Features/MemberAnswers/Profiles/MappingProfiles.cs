using Application.Features.MemberAnswers.Commands.Create;
using Application.Features.MemberAnswers.Commands.Delete;
using Application.Features.MemberAnswers.Commands.Update;
using Application.Features.MemberAnswers.Queries.GetById;
using Application.Features.MemberAnswers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MemberAnswers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMemberAnswerCommand, MemberAnswer>();
        CreateMap<MemberAnswer, CreatedMemberAnswerResponse>();

        CreateMap<UpdateMemberAnswerCommand, MemberAnswer>();
        CreateMap<MemberAnswer, UpdatedMemberAnswerResponse>();

        CreateMap<DeleteMemberAnswerCommand, MemberAnswer>();
        CreateMap<MemberAnswer, DeletedMemberAnswerResponse>();

        CreateMap<MemberAnswer, GetByIdMemberAnswerResponse>();

        CreateMap<MemberAnswer, GetListMemberAnswerListItemDto>();
        CreateMap<IPaginate<MemberAnswer>, GetListResponse<GetListMemberAnswerListItemDto>>();
    }
}