using Api.Abstractions;
using Application.Users.Auth.Login;
using Application.Users.Auth.Register;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    public AuthenticationController(ISender sender)
        : base(sender) { }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = Sender.Send(new LoginCommand(request.Email, request.Password)).Result;

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
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
        var result = Sender
            .Send(new RegisterCommand(
                    request.Email,
                    request.Password,
                    request.FirstName,
                    request.LastName
                )
            ).Result;

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
