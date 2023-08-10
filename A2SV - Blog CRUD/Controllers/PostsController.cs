using A2SV___Blog_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SV___Blog_CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class postsController : ControllerBase
{
    private static AppDbContext _context;
    public postsController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var posts = await _context.Posts.ToListAsync();

        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();
        
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", post.Id, post);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(int id, Post post)
    {
        var p = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        
        if (p == null) return NotFound();
        
        p.Title = post.Title;
        p.Content = post.Content;
        p.CreatedAt = post.CreatedAt;
        
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        
        if (post == null) return NotFound();
        
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}