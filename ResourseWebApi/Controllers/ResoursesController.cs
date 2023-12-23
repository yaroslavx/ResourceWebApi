using Microsoft.AspNetCore.Mvc;
using ResourseWebApi.Contracts.Resourse;
using ResourseWebApi.Models;
using ResourseWebApi.Services.Resourses;

namespace ResourseWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ResoursesController : ControllerBase
{
    private readonly ICustomResourseService _resourseService;

    public ResoursesController(ICustomResourseService resourseService)
    {
        _resourseService = resourseService;
    }

    [HttpPost]
    public IActionResult CreateResourse(CreateResourseRequest request)
    {
        var resourse = new Resourse(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Primary,
            request.Secondary
        );

        _resourseService.CreateResourse(resourse);

        var response = new ResourseResponse(
            resourse.Id,
            resourse.Name,
            resourse.Description,
            resourse.StartDateTime,
            resourse.EndDateTime,
            resourse.LastModifiedDateTime,
            resourse.Primary,
            resourse.Secondary
        );
        return CreatedAtAction(
            actionName: nameof(GetResourse),
            routeValues: new { id = resourse.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetResourse(Guid id)
    {
        Resourse resourse = _resourseService.GetResourse(id);

        var response = new ResourseResponse(
            resourse.Id,
            resourse.Name,
            resourse.Description,
            resourse.StartDateTime,
            resourse.EndDateTime,
            resourse.LastModifiedDateTime,
            resourse.Primary,
            resourse.Secondary
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateResourse(Guid id, UpsertResourseRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteResourse(Guid id)
    {
        return Ok(id);
    }
}