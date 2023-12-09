using Api.Abstractions;
using Infrastructure.Services.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class UserController : ApiController
{
    [HttpGet("guest")]
    public IActionResult Guest() => Ok("Hello Guest");

    [HttpGet("host")]
    [Authorize(Policy = nameof(PermissionRequirement.Host))]
    public IActionResult Host() => Ok("Hello Host");
}
