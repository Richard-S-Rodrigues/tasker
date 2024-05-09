using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DebugController : ControllerBase
{
  private readonly ISender _sender;
  public DebugController(ISender sender)
  {   
    _sender = sender;
  }

  [HttpPost]
  public async Task<IActionResult> CreateBoard(string name)
  {
    var command = new CreateBoardCommand(name);
    
    await _sender.Send(command);
    return Ok();
  }

  [HttpPost]
  public async Task<IActionResult> CreateTask([FromBody] CreateTaskDTO createTaskDTO)
  {
    try 
    {
      var command = new CreateTaskCommand(
        new BoardId(createTaskDTO.BoardId), 
        createTaskDTO.Title,
        createTaskDTO.Description,
        createTaskDTO.TimeDetails,
        createTaskDTO.Priority,
        createTaskDTO.Responsibles);
      
      await _sender.Send(command);
      return Ok();
    }
    catch (ValidationException ex)
    {
      return BadRequest(string.Join(", ", ex.Errors.Select(e => e.ErrorMessage)));
    }
    
  } 
}

public record CreateTaskDTO(
  Guid BoardId,
  string Title,
  string? Description,
  TimeDetails TimeDetails,
  Priority Priority,
  List<Responsible> Responsibles);