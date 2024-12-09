namespace Pronia.Models
{
    public class CommentProduct : BaseEntity
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}