using Application.Features.Questions.Commands.Create;
using Application.Features.Questions.Commands.Delete;
using Application.Features.Questions.Commands.Update;
using Application.Features.Questions.Queries.GetById;
using Application.Features.Questions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Questions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<Question, CreatedQuestionResponse>();

        CreateMap<UpdateQuestionCommand, Question>();
        CreateMap<Question, UpdatedQuestionResponse>();

        CreateMap<DeleteQuestionCommand, Question>();
        CreateMap<Question, DeletedQuestionResponse>();

        CreateMap<Question, GetByIdQuestionResponse>();

        CreateMap<Question, GetListQuestionListItemDto>();
        CreateMap<IPaginate<Question>, GetListResponse<GetListQuestionListItemDto>>();
    }
}