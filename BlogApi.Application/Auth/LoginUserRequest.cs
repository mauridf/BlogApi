﻿namespace BlogApi.Application.Auth;

public class LoginUserRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
