using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("list-pagination")]
    public IActionResult GetListPagnition([FromQuery] Pagination pagination)
    {
        var data = _personService.GetPagnition(pagination);

        return Ok(data);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PersonModel>> GetFilterList(string? name, string? gender, string? birthPlace)
    {
        try
        {
            var queryEntities = _personService.GetFilterList(name, gender, birthPlace);

            return Ok(queryEntities);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] PersonCreateModel createModel)
    {
        if (createModel != null)
        {
            try
            {
                var result = _personService.Create(createModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] PersonUpdateModel updateModel)
    {
        try
        {
            var result = _personService.Update(id, updateModel);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _personService.Delete(id);

            return Ok($"Done Delete: {id}");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}