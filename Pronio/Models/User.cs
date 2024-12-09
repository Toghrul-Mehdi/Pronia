using Microsoft.AspNetCore.Identity;

namespace Pronia.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string ProfileImageUrl { get; set; }
        public ICollection<CommentUser> CommentUsers { get; set; }
        public ICollection<ProductRatings>? ProductRatings { get; set; }
    }
}
