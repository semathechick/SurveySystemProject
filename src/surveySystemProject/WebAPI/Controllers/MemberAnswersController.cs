using Application.Features.MemberAnswers.Commands.Create;
using Application.Features.MemberAnswers.Commands.Delete;
using Application.Features.MemberAnswers.Commands.Update;
using Application.Features.MemberAnswers.Queries.GetById;
using Application.Features.MemberAnswers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberAnswersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMemberAnswerResponse>> Add([FromBody] CreateMemberAnswerCommand command)
    {
        CreatedMemberAnswerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMemberAnswerResponse>> Update([FromBody] UpdateMemberAnswerCommand command)
    {
        UpdatedMemberAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMemberAnswerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteMemberAnswerCommand command = new() { Id = id };

        DeletedMemberAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMemberAnswerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdMemberAnswerQuery query = new() { Id = id };

        GetByIdMemberAnswerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMemberAnswerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMemberAnswerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMemberAnswerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}