using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;
using Pronia.ViewModel.Basket;
using System.Text.Json;

namespace Pronia.ViewComponents
{
    public class HeaderViewComponent(AppDbContext _context) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketItems = JsonSerializer.Deserialize<List<BasketProductItemVM>>(Request.Cookies["basket"] ?? "[]");
            var prods = await _context.Products
                .Where(x => basketItems.Select(y => y.Id).Any(y => y == x.Id))
                .Select(x => new BasketProduct
                {
                    Id = x.Id,
                    Name = x.ProductName,
                    SellPrice = x.SellPrice,
                    Discount = x.Discount,
                    ImageUrl = x.CoverImage,
                }).ToListAsync();
            foreach (var item in prods)
            {
                item.Count = basketItems!.FirstOrDefault(x => x.Id == item.Id)!.Count;
            }
            return View(prods);
        }
    }
}
