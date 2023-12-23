using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ResourseWebApi.Contracts.Resourse;
using ResourseWebApi.Models;
using ResourseWebApi.ServiceErrors;
using ResourseWebApi.Services.Resourses;

namespace ResourseWebApi.Controllers;

public class ResoursesController : ApiController
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

        ErrorOr<Created> createResourseResult = _resourseService.CreateResourse(resourse);

        return createResourseResult.Match(
            created => CreatedAtGetResourse(resourse),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetResourse(Guid id)
    {
        ErrorOr<Resourse> getResourseResult = _resourseService.GetResourse(id);

        return getResourseResult.Match(
            resourse => Ok(MapResourseResponse(resourse)),
            errors => Problem(errors)
        );

    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertResourse(Guid id, UpsertResourseRequest request)
    {
        var resourse = new Resourse(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Primary,
            request.Secondary
        );

        ErrorOr<UpsertedResourse> upserteResourseResult = _resourseService.UpsertResourse(resourse);

        return upserteResourseResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetResourse(resourse) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteResourse(Guid id)
    {
        ErrorOr<Deleted> deleteResourseResult = _resourseService.DeleteResourse(id);
        return deleteResourseResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static ResourseResponse MapResourseResponse(Resourse resourse)
    {
        return new ResourseResponse(
            resourse.Id,
            resourse.Name,
            resourse.Description,
            resourse.StartDateTime,
            resourse.EndDateTime,
            resourse.LastModifiedDateTime,
            resourse.Primary,
            resourse.Secondary
        );
    }

    private CreatedAtActionResult CreatedAtGetResourse(Resourse resourse)
    {
        return CreatedAtAction(
                    actionName: nameof(GetResourse),
                    routeValues: new { id = resourse.Id },
                    value: MapResourseResponse(resourse));
    }
}