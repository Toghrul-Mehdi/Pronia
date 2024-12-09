using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.ViewModel.Common;
using Pronia.ViewModel;
using Pronio.Models;
using Pronia.DataAccess;

namespace Pronio.Controllers
{
    public class HomeController(AppDbContext _context) : Controller
    {     

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM();
            vm.Sliders = await _context.Sliders
                .Where(x => !x.IsDeleted)
                .Select(x => new SliderItemVM
                {                    
                    ImageUrl = x.ImageUrl,
                    Subtitle = x.Subtitle,
                    Title = x.Title,
                }).ToListAsync();
            vm.Products = await _context.Products
                .Where(x => !x.IsDeleted)
                .Select(x => new ProductItemVM
                {
                    Id = x.Id,
                    ImageUrl = x.CoverImage,
                    Name = x.ProductName,
                    Price = x.SellPrice,
                    Discount = x.Discount,
                    IsInStock = x.Quantity > 0,
                    CategoryID = x.CategoryID
                }).ToListAsync();
            vm.Categories = await _context.Categories
                .Where(x => !x.IsDeleted)
                .Select(x => new CategoryItemVM
                {
                    Id=x.Id,
                    CategoryName = x.CategoryName,
                }).ToListAsync();
            return View(vm);
        }    
        

        
    }
}
