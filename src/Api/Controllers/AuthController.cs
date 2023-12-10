using Application.Users.Auth.Login;
using Application.Users.Auth.Register;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api.Commons;

namespace Api.Controllers;

[AllowAnonymous]
public class AuthController(ISender sender) : ApiController
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = sender.Send(new LoginQuery(request.Email, request.Password)).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = new AuthenticationResponse(
            result.Value.User.Id.Value,
            result.Value.User.Email,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.Token
        );
        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = sender
            .Send(new RegisterCommand(
                    request.Email,
                    request.Password,
                    request.FirstName,
                    request.LastName
                )
            ).Result;

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        var response = new AuthenticationResponse(
            result.Value.User.Id.Value,
            result.Value.User.Email,
            result.Value.User.FirstName,
            result.Value.User.LastName,
            result.Value.Token
        );
        return Ok(response);
    }
}
