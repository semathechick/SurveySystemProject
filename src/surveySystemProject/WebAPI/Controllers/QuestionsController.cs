using Application.Features.Questions.Commands.Create;
using Application.Features.Questions.Commands.Delete;
using Application.Features.Questions.Commands.Update;
using Application.Features.Questions.Queries.GetById;
using Application.Features.Questions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedQuestionResponse>> Add([FromBody] CreateQuestionCommand command)
    {
        CreatedQuestionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedQuestionResponse>> Update([FromBody] UpdateQuestionCommand command)
    {
        UpdatedQuestionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedQuestionResponse>> Delete([FromRoute] Guid id)
    {
        DeleteQuestionCommand command = new() { Id = id };

        DeletedQuestionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdQuestionResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdQuestionQuery query = new() { Id = id };

        GetByIdQuestionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListQuestionQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListQuestionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListQuestionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}