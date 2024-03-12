﻿namespace Lir.Api.GraphQL.InputTypes
{
    public class RegisterInputType
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
