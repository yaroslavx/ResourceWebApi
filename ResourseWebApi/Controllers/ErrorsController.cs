using Microsoft.AspNetCore.Mvc;

namespace ResourseWebApi.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}