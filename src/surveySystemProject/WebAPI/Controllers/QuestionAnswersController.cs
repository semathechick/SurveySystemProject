using Application.Features.QuestionAnswers.Commands.Create;
using Application.Features.QuestionAnswers.Commands.Delete;
using Application.Features.QuestionAnswers.Commands.Update;
using Application.Features.QuestionAnswers.Queries.GetById;
using Application.Features.QuestionAnswers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionAnswersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedQuestionAnswerResponse>> Add([FromBody] CreateQuestionAnswerCommand command)
    {
        CreatedQuestionAnswerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedQuestionAnswerResponse>> Update([FromBody] UpdateQuestionAnswerCommand command)
    {
        UpdatedQuestionAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedQuestionAnswerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteQuestionAnswerCommand command = new() { Id = id };

        DeletedQuestionAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdQuestionAnswerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdQuestionAnswerQuery query = new() { Id = id };

        GetByIdQuestionAnswerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListQuestionAnswerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListQuestionAnswerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListQuestionAnswerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}