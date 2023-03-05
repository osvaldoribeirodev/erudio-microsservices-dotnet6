using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public PersonController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    // [FromServices] IPersonService personService -> Injeção de dependencia dotnet 6
    public IActionResult Get([FromServices] IPersonService personService)
    {
        return Ok(personService.FindAll());
    }

    [HttpGet("{id:long}")]
    public IActionResult Get([FromServices] IPersonService personService, long id)
    {
        var person = personService.FindByID(id);
        if (person == null) return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromServices] IPersonService personService, [FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(personService.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromServices] IPersonService personService, [FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(personService.Update(person));
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete([FromServices] IPersonService personService, long id)
    {
        personService.Delete(id);
        return NoContent();
    }
}