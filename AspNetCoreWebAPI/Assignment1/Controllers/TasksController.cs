using Assignment1.Models;
using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger, ITaskService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetListTasks")]
    public List<TaskModel> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public TaskModel Add([FromBody] TaskModel model)
    {
        var task = new TaskModel
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            IsCompleted = model.IsCompleted
        };
        return _service.Add(task);
    }

    [HttpPut]
    public IActionResult Edit(Guid id, TaskModel model)
    {
        var task = _service.GetOne(id);

        if (task != null)
        {
            task.Title = model.Title;
            task.IsCompleted = model.IsCompleted;

            var result = _service.Edit(task);
            return new JsonResult(result);
        }

        return NotFound();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        var task = _service.GetOne(id);

        if (task != null)
        {
            _service.Delete(id);
            return Ok();
        }

        return NotFound();
    }

    [HttpPost]
    [Route("multiple-add")]
    public List<TaskModel> AddMultiple(List<TaskModel> models)
    {
        var tasks = new List<TaskModel>();

        foreach (var model in models)
        {
            tasks.Add(new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                IsCompleted = model.IsCompleted
            });
        }
        return _service.Add(tasks);
    }

    [HttpPost]
    [Route("multiple-delete")]
    public IActionResult DeleteMultiple(List<Guid> ids)
    {
        _service.Delete(ids);
        return Ok();
    }
}
