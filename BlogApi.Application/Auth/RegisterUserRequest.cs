﻿namespace BlogApi.Application.Auth;

public class RegisterUserRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
