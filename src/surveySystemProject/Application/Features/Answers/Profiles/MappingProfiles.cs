using Application.Features.Answers.Commands.Create;
using Application.Features.Answers.Commands.Delete;
using Application.Features.Answers.Commands.Update;
using Application.Features.Answers.Queries.GetById;
using Application.Features.Answers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Answers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAnswerCommand, Answer>();
        CreateMap<Answer, CreatedAnswerResponse>();

        CreateMap<UpdateAnswerCommand, Answer>();
        CreateMap<Answer, UpdatedAnswerResponse>();

        CreateMap<DeleteAnswerCommand, Answer>();
        CreateMap<Answer, DeletedAnswerResponse>();

        CreateMap<Answer, GetByIdAnswerResponse>();

        CreateMap<Answer, GetListAnswerListItemDto>();
        CreateMap<IPaginate<Answer>, GetListResponse<GetListAnswerListItemDto>>();
    }
}