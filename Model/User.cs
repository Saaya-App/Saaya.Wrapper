﻿#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class User
    {
        public string? Avatar { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
