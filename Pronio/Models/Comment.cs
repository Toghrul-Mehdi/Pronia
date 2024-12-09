namespace Pronia.Models
{
    public class Comment : BaseEntity
    {
        public string Comments { get; set; }   
        public ICollection<CommentUser> CommentUsers { get; set; }
        public ICollection<CommentProduct> CommentProducts { get; set; }
    }
}
