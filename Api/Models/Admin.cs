using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Api.Models
{
    public class Admin : IdentityUser<int>
    {
        [Required]
        [EmailAddress]
        public new string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}