﻿namespace BlogApi.Application.Auth;

public class AuthResponse
{
    public string Token { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
