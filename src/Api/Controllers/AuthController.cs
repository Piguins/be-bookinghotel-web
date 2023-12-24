using Application.Users.Auth.Login;
using Application.Users.Auth.Register;
using Contracts.Auth;
using Contracts.Auth.Requests;
using Domain.Users.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Commons;

namespace Api.Controllers;

[Route("api/[controller]")]
public class AuthController(ISender sender) : ApiController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = sender.Send(new LoginQuery(request.Email, request.Password)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = new AuthResponse(
            result.Value.User.Id.Value,
            result.Value.User.Email,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.User.Roles.Any(r => r.Equals(Role.Host)),
            result.Value.Token
        );
        return Ok(response);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public IActionResult Register(RegisterRequest request)
    {
        var result = sender
            .Send(new RegisterCommand(
                    request.Email,
                    request.Password,
                    request.FirstName,
                    request.LastName,
                    false
                )
            ).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = new AuthResponse(
            result.Value.User.Id.Value,
            result.Value.User.Email,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.User.Roles.Any(r => r.Equals(Role.Host)),
            result.Value.Token
        );
        return Ok(response);
    }

    [HttpPost("register-host")]
    [AllowAnonymous]
    public IActionResult RegisterHost(RegisterRequest request)
    {
        var result = sender
            .Send(new RegisterCommand(
                    request.Email,
                    request.Password,
                    request.FirstName,
                    request.LastName,
                    true
                )
            ).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = new AuthResponse(
            result.Value.User.Id.Value,
            result.Value.User.Email,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.User.Roles.Any(r => r.Equals(Role.Host)),
            result.Value.Token
        );
        return Ok(response);
    }
}
