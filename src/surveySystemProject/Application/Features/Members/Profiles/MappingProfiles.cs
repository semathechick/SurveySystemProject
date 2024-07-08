using Application.Features.Members.Commands.Create;
using Application.Features.Members.Commands.Delete;
using Application.Features.Members.Commands.Update;
using Application.Features.Members.Queries.GetById;
using Application.Features.Members.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Members.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMemberCommand, Member>();
        CreateMap<Member, CreatedMemberResponse>();

        CreateMap<UpdateMemberCommand, Member>();
        CreateMap<Member, UpdatedMemberResponse>();

        CreateMap<DeleteMemberCommand, Member>();
        CreateMap<Member, DeletedMemberResponse>();

        CreateMap<Member, GetByIdMemberResponse>();

        CreateMap<Member, GetListMemberListItemDto>();
        CreateMap<IPaginate<Member>, GetListResponse<GetListMemberListItemDto>>();
    }
}