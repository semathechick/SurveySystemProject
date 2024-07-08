using Application.Features.SurveyAnswers.Commands.Create;
using Application.Features.SurveyAnswers.Commands.Delete;
using Application.Features.SurveyAnswers.Commands.Update;
using Application.Features.SurveyAnswers.Queries.GetById;
using Application.Features.SurveyAnswers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveyAnswersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSurveyAnswerResponse>> Add([FromBody] CreateSurveyAnswerCommand command)
    {
        CreatedSurveyAnswerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSurveyAnswerResponse>> Update([FromBody] UpdateSurveyAnswerCommand command)
    {
        UpdatedSurveyAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSurveyAnswerResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSurveyAnswerCommand command = new() { Id = id };

        DeletedSurveyAnswerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSurveyAnswerResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSurveyAnswerQuery query = new() { Id = id };

        GetByIdSurveyAnswerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSurveyAnswerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSurveyAnswerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSurveyAnswerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}