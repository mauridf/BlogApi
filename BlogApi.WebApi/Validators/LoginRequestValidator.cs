﻿using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace BlogApi.WebApi.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
