using Api.Abstractions;
using Application.Users.Auth.Login;
using Application.Users.Auth.Register;
using Contracts.Authentication;
using Infrastructure.Services.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

public class UserController(ISender sender) : ApiController
{
    [HttpGet("guest")]
    public IActionResult Guest() => Ok("Hello Guest");

    [HttpGet("host")]
    [Authorize(Policy = nameof(PermissionRequirement.Host))]
    public IActionResult Host() => Ok("Hello Host");
}
