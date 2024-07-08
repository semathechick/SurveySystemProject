using Application.Features.MemberQuestions.Commands.Create;
using Application.Features.MemberQuestions.Commands.Delete;
using Application.Features.MemberQuestions.Commands.Update;
using Application.Features.MemberQuestions.Queries.GetById;
using Application.Features.MemberQuestions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.MemberQuestions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateMemberQuestionCommand, MemberQuestion>();
        CreateMap<MemberQuestion, CreatedMemberQuestionResponse>();

        CreateMap<UpdateMemberQuestionCommand, MemberQuestion>();
        CreateMap<MemberQuestion, UpdatedMemberQuestionResponse>();

        CreateMap<DeleteMemberQuestionCommand, MemberQuestion>();
        CreateMap<MemberQuestion, DeletedMemberQuestionResponse>();

        CreateMap<MemberQuestion, GetByIdMemberQuestionResponse>();

        CreateMap<MemberQuestion, GetListMemberQuestionListItemDto>();
        CreateMap<IPaginate<MemberQuestion>, GetListResponse<GetListMemberQuestionListItemDto>>();
    }
}