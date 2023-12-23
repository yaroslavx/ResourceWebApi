using Microsoft.AspNetCore.Mvc;
using ResourseWebApi.Contracts.Resourse;

namespace ResourseWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ResoursesController : ControllerBase
{
    [HttpPost("")]
    public IActionResult CreateResourse(CreateResourseRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetResourse(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertResourse(Guid id, UpsertResourseRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteResourse(Guid id)
    {
        return Ok(id);
    }
}