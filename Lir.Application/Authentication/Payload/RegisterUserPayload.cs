﻿using Lir.Core.Models;

namespace Lir.Application.Authentication.Payload
{
    public class RegisterUserPayload
    {
        public User? User { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string Message { get; set; }
    }
}