using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("errors")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Problem();
}

