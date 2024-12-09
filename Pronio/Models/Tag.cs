namespace Pronia.Models
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
