using AppCore.Interfaces.Repositories;
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
        DE.Task task = Repository.Handle(new AQ.GetTaskByIdQuery(id));
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [Route("Get")]
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<DE.Task> tasks = Repository.Handle(new AQ.GetAllTasksQuery());

        if (tasks == null || tasks.Count() <= 0)
            return NotFound();

        return Ok(tasks);
    }

    [Route("Complete/{id}")]
    [HttpPatch]
    public IActionResult UpdateCompletion(int id)
    {
        bool result = Repository.Handle(new AC.UpdateTaskCompletionCommand(id));
        return result ? Ok(result) : NotFound();
    }

    [Route("Update/{id}")]
    [HttpPut]
    public IActionResult Update(int id, [FromBody] TaskDto dto)
    {
        bool result = Repository.Handle(new AC.UpdateTaskCommand(id, dto.Title));
        return result ? Ok(result) : NotFound();
    }

    [Route("Delete/{id}")]
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        bool result = Repository.Handle(new AC.DeleteTaskCommand(id));
        return result ? Ok(result) : NotFound();
    }

    [Route("Add")]
    [HttpPost]
    public IActionResult Add([FromBody] TaskDto dto)
    {
        //TODO the result shoudl be the id of the new element !
        bool result = Repository.Handle(new AC.AddTaskCommand(dto.Title));
        return result ? Ok(result) : NotFound();
    }
}
