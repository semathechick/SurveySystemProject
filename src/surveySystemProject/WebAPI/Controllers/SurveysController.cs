using Application.Features.Surveys.Commands.Create;
using Application.Features.Surveys.Commands.Delete;
using Application.Features.Surveys.Commands.Update;
using Application.Features.Surveys.Queries.GetById;
using Application.Features.Surveys.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSurveyResponse>> Add([FromBody] CreateSurveyCommand command)
    {
        CreatedSurveyResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSurveyResponse>> Update([FromBody] UpdateSurveyCommand command)
    {
        UpdatedSurveyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSurveyResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSurveyCommand command = new() { Id = id };

        DeletedSurveyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSurveyResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSurveyQuery query = new() { Id = id };

        GetByIdSurveyResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSurveyQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSurveyQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSurveyListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}