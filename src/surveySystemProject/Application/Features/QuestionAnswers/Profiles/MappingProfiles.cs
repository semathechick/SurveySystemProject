using Application.Features.QuestionAnswers.Commands.Create;
using Application.Features.QuestionAnswers.Commands.Delete;
using Application.Features.QuestionAnswers.Commands.Update;
using Application.Features.QuestionAnswers.Queries.GetById;
using Application.Features.QuestionAnswers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.QuestionAnswers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateQuestionAnswerCommand, QuestionAnswer>();
        CreateMap<QuestionAnswer, CreatedQuestionAnswerResponse>();

        CreateMap<UpdateQuestionAnswerCommand, QuestionAnswer>();
        CreateMap<QuestionAnswer, UpdatedQuestionAnswerResponse>();

        CreateMap<DeleteQuestionAnswerCommand, QuestionAnswer>();
        CreateMap<QuestionAnswer, DeletedQuestionAnswerResponse>();

        CreateMap<QuestionAnswer, GetByIdQuestionAnswerResponse>();

        CreateMap<QuestionAnswer, GetListQuestionAnswerListItemDto>();
        CreateMap<IPaginate<QuestionAnswer>, GetListResponse<GetListQuestionAnswerListItemDto>>();
    }
}