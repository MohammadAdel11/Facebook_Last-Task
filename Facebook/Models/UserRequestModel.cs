﻿namespace FirstApi.Models
{
    public class UserRequestModel
    {
        public required string email { get; set; }
        public  string? FullName { get; set; }
        public required string Password { get; set; }
        public  string? ConfirmPassword { get; set; }
    }
}
