using Application.Features.SurveyMembers.Commands.Create;
using Application.Features.SurveyMembers.Commands.Delete;
using Application.Features.SurveyMembers.Commands.Update;
using Application.Features.SurveyMembers.Queries.GetById;
using Application.Features.SurveyMembers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveyMembersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSurveyMemberResponse>> Add([FromBody] CreateSurveyMemberCommand command)
    {
        CreatedSurveyMemberResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSurveyMemberResponse>> Update([FromBody] UpdateSurveyMemberCommand command)
    {
        UpdatedSurveyMemberResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSurveyMemberResponse>> Delete([FromRoute] Guid id)
    {
        DeleteSurveyMemberCommand command = new() { Id = id };

        DeletedSurveyMemberResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSurveyMemberResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdSurveyMemberQuery query = new() { Id = id };

        GetByIdSurveyMemberResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSurveyMemberQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSurveyMemberQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSurveyMemberListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}