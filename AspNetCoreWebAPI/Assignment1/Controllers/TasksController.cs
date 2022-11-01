using Assignment1.Models;
using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public ActionResult<List<TaskModel>> GetAll()
    {
        try
        {
            var model = _service.GetAll();

            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<TaskModel> GetOne(Guid id)
    {
        try
        {
            var model = _service.GetOne(id);

            if (model != null)
            {
                return Ok(model);
            }
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public ActionResult<TaskModel> Add([FromBody] TaskModel model)
    {
        if (model != null)
        {
            try
            {
                var task = new TaskModel
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    IsCompleted = model.IsCompleted
                };

                return _service.Add(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Edit(Guid id, TaskModel model)
    {
        var task = _service.GetOne(id);

        if (task != null)
        {
            try
            {
                task.Title = model.Title;
                task.IsCompleted = model.IsCompleted;

                var result = _service.Edit(task);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var task = _service.GetOne(id);

        if (task != null)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        return NotFound();
    }

    [HttpPost]
    [Route("multiple")]
    public async Task<IActionResult> AddMultiple(List<TaskModel> models)
    {
        if (models != null)
        {
            var tasks = new List<TaskModel>();
            try
            {
                foreach (var model in models)
                {
                    tasks.Add(new TaskModel
                    {
                        Id = Guid.NewGuid(),
                        Title = model.Title,
                        IsCompleted = model.IsCompleted
                    });
                }

                await _service.Add(tasks);

                return Accepted(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("multiple-deletion")]
    public async Task<ActionResult> DeleteMultiple(List<Guid> ids)
    {
        try
        {
            await _service.Delete(ids);

            return Accepted(ids);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}