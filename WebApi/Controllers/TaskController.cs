using AppCore.Features.Results;
using AppCore.Interfaces.Repositories;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using AC = AppCore.Features.Commands;
using AQ = AppCore.Features.Queries;
using DE = Domain.Entities;

namespace WebApi.Controllers;

//Create

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskRepository Repository) : ControllerBase
{
    [Route("Get/{id}")]
    [HttpGet()]
    public IActionResult GetById(int id)
    {
        Result<DE.Task> result = Repository.Handle(new AQ.GetTaskByIdQuery(id));
        return this.FromResult(result);
    }

    [Route("GetAsync/{id}")]
    [HttpGet()]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        Result<DE.Task> result = await Repository.HandleAsync(new AQ.GetTaskByIdQuery(id));
        return this.FromResult(result);
    }

    [Route("Get")]
    [HttpGet]
    public IActionResult GetAll()
    {
        Result<IEnumerable<DE.Task>> result = Repository.Handle(new AQ.GetAllTasksQuery());
        return this.FromResult(result);
    }

    [Route("GetAsync")]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        Result<IEnumerable<DE.Task>> result = await Repository.HandleAsync(
            new AQ.GetAllTasksQuery()
        );
        return this.FromResult(result);
    }

    [Route("Complete/{id}")]
    [HttpPatch]
    public IActionResult UpdateCompletion(int id)
    {
        Result result = Repository.Handle(new AC.UpdateTaskCompletionCommand(id));
        return this.FromResult(result);
    }

    [Route("Update/{id}")]
    [HttpPut]
    public IActionResult Update(int id, [FromBody] UpdateTaskDto dto)
    {
        Result result = Repository.Handle(new AC.UpdateTaskCommand(id, dto.Title, dto.Completed));
        return this.FromResult(result);
    }

    [Route("Delete/{id}")]
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Result result = Repository.Handle(new AC.DeleteTaskCommand(id));
        return this.FromResult(result);
    }

    [Route("Add")]
    [HttpPost]
    public IActionResult Add([FromBody] CreateTaskDto dto)
    {
        //TODO the result shoudl be the id of the new element !
        Result<int> result = Repository.Handle(new AC.AddTaskCommand(dto.Title));
        return this.FromResult(result);
    }
}
