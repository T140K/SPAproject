using Microsoft.AspNetCore.Identity;

namespace SPAproject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nick { get; set; }

    }
}