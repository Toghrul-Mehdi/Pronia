using Microsoft.AspNetCore.Identity;

namespace Pronia.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
