using Api.Abstractions;
using Application.Authentication;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(
        ISender sender,
        IAuthenticationService authenticationService)
        : base(sender)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            result.User.Id.Value,
            result.User.Email,
            result.User.FirstName,
            result.User.LastName,
            result.Token);
        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName);

        var response = new AuthenticationResponse(
            result.User.Id.Value,
            result.User.Email,
            result.User.FirstName,
            result.User.LastName,
            result.Token);
        return Ok(response);
    }
}
