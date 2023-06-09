﻿using ChatApplication.Shared.Models.Auth;
using FluentValidation;

namespace ChatApplication.BLL.Validators.Auth;

public class LoginModelValidator: AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(lm => lm.Email)
            .NotEmpty().WithMessage("Email must not be empty")
            .EmailAddress().WithMessage("Must be a valid email");

        RuleFor(lm => lm.Password)
            .NotEmpty().WithMessage("Password must not be empty");
    }
}