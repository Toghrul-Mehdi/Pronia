namespace Pronia.Models
{
    public class CommentUser : BaseEntity
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public User User { get; set; }
    }
}