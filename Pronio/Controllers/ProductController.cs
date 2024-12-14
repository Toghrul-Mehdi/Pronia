using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;
using Pronia.Models;
using Pronia.ViewModel;
using Pronia.ViewModel.Basket;
using System.Security.Claims;
using System.Text.Json;

namespace Pronia.Controllers
{
    public class ProductController(AppDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(!id.HasValue) return BadRequest();
            var data = await _context.Products
               .Where(x => x.Id == id)
               .Include(x => x.Images)
               .Include(x => x.ProductRatings)
               .Include(x => x.Comments)
               .ThenInclude(c => c.User)
               .FirstOrDefaultAsync();
            if (data == null) return NotFound();   
            return View(data);
        }

        

       
        public async Task<IActionResult> Comment(int productId, CommentVM vm)
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            var data = await _context.Comments.Where(x => x.UserId == userId && x.ProductId == productId).FirstOrDefaultAsync();


            Comment comment = new Comment
            {                
                Comments = vm.Comment,
                ProductId = productId,
                UserId = userId,
            };

            await _context.Comments.AddAsync(comment);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { Id = productId });
        }


        public async Task<IActionResult> AddBasket(int id)
        {
            var basketItems = JsonSerializer.Deserialize<List<BasketProductItemVM>>(Request.Cookies["basket"] ?? "[]");

            var item  = basketItems.FirstOrDefault(x=>x.Id == id);
            if (item == null)
            {
                item = new BasketProductItemVM(id);
                basketItems.Add(item);
            }
            item.Count++;
            Response.Cookies.Append("basket", JsonSerializer.Serialize(basketItems));

            return RedirectToAction(nameof(Details), new {Id = id});
        }


        public async Task<IActionResult> DeleteBasket(int id)
        {
            var basketItems = JsonSerializer.Deserialize<List<BasketProductItemVM>>(Request.Cookies["basket"] ?? "[]");

            var item = basketItems!.FirstOrDefault(x => x.Id == id);
            if (item!.Count>1)
            {                
                item.Count--;
            }
            else
            {
                basketItems!.Remove(item);
            }
            
            Response.Cookies.Append("basket", JsonSerializer.Serialize(basketItems));

            return RedirectToAction(nameof(Details), new { Id = id });
        }
    }

}
