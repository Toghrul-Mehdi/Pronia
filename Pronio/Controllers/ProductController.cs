using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;
using Pronia.Models;
using Pronia.ViewModel;

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
                .Where(x => x.Id == id.Value && !x.IsDeleted)
                .Include(x=>x.Images)
                .FirstOrDefaultAsync();
            if(data == null) return NotFound();   
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentVM vm)
        {
            Comment comment = new Comment
            {
                
                Comments = vm.Comment                
                
            };
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
        }
    }

}
