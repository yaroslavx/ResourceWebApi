using Microsoft.AspNetCore.Mvc;
using ResourseWebApi.Contracts.Resourse;

namespace ResourseWebApi.Controllers;

[ApiController]
public class ResoursesController : ControllerBase
{
    [HttpPost("/resourse")]
    public IActionResult CreateResourse(CreateResourseRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/resourse/{id:guid}")]
    public IActionResult GetResourse(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/resourse/{id:guid}")]
    public IActionResult UpsertResourse(Guid id, UpsertResourseRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/resourse/{id:guid}")]
    public IActionResult DeleteResourse(Guid id)
    {
        return Ok(id);
    }
}