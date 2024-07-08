using Application.Features.Answers.Commands.Create;
using Application.Features.Answers.Commands.Delete;
using Application.Features.Answers.Commands.Update;
using Application.Features.Answers.Queries.GetById;
using Application.Features.Answers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAnswerResponse>> Add([FromBody] CreateAnswerCommand command)
    {
        CreatedAnswerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAnswerResponse>> Update([FromBody] UpdateAnswerCommand command)
    {
        UpdatedAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAnswerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAnswerCommand command = new() { Id = id };

        DeletedAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAnswerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAnswerQuery query = new() { Id = id };

        GetByIdAnswerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAnswerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAnswerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAnswerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}