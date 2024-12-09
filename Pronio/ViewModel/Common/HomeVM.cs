namespace Pronia.ViewModel.Common
{
    public class HomeVM
    {
        public IEnumerable<SliderItemVM> Sliders { get; set; }
        public IEnumerable<ProductItemVM> Products { get; set; }
        public IEnumerable<CategoryItemVM> Categories { get; set; }
        public IEnumerable<CommentVM> Comments { get; set; }
    }
}
