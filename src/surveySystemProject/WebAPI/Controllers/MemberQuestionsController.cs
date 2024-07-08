using Application.Features.MemberQuestions.Commands.Create;
using Application.Features.MemberQuestions.Commands.Delete;
using Application.Features.MemberQuestions.Commands.Update;
using Application.Features.MemberQuestions.Queries.GetById;
using Application.Features.MemberQuestions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberQuestionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMemberQuestionResponse>> Add([FromBody] CreateMemberQuestionCommand command)
    {
        CreatedMemberQuestionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMemberQuestionResponse>> Update([FromBody] UpdateMemberQuestionCommand command)
    {
        UpdatedMemberQuestionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMemberQuestionResponse>> Delete([FromRoute] Guid id)
    {
        DeleteMemberQuestionCommand command = new() { Id = id };

        DeletedMemberQuestionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMemberQuestionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdMemberQuestionQuery query = new() { Id = id };

        GetByIdMemberQuestionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMemberQuestionQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberQuestionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMemberQuestionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}