﻿using System.Drawing;
using ChatApplication.BLL.Abstractions.Services;
using ChatApplication.Shared.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(
        IAuthService authService,
        IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Test()
    {
        var blobStorageConnectionString = _configuration.GetSection("Azure:Blob:ConnectionString").Value;
        var signalRConnectionString = _configuration.GetSection("Azure:SignalR:ConnectionString").Value;

        return Ok(new List<string>
        {
            blobStorageConnectionString, signalRConnectionString
        });
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await _authService.LoginAsync(loginModel);
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Signup(SignupModel signupModel)
    {
        await _authService.SignupAsync(signupModel);
        return Ok();
    }

    [HttpPut("changePassword")]
    public async Task<IActionResult> ChangePassword(
        ChangePasswordModel changePasswordModel)
    {
        await _authService.ResetPasswordAsync(changePasswordModel);
        return NoContent();
    }
}