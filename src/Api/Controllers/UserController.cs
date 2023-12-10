using Api.Commons;
using Application.Users.Queries.GetAllUsers;
using Contracts.User;
using Infrastructure.Services.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using AutoMapper;

namespace Api.Controllers;

public class UserController(ISender sender, IMapper mapper) : ApiController
{
    [HttpGet("get-all")]
    [AllowAnonymous]
    public IActionResult GetAllUsers()
    {
        var result = sender.Send(new GetAllUsersQuery()).Result;

        return result.IsFailure
            ? HandleFailure(result)
            : Ok(result.Value.Select(mapper.Map<UserResponse>));
    }

    [HttpGet("hello-guest")]
    [Authorize(Policy = nameof(PermissionRequirement.Guest))]
    public IActionResult Guest() => Ok("Hello Guest");

    [HttpGet("hello-host")]
    [Authorize(Policy = nameof(PermissionRequirement.Host))]
    public IActionResult Host() => Ok("Hello Host");
}
