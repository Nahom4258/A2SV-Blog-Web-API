using A2SV___Blog_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A2SV___Blog_CRUD.Controllers;

[Route("api/posts")]     // api/comments
[ApiController]
public class commentsController : ControllerBase
{
    private static AppDbContext _context;
    
    public commentsController(AppDbContext context)
    {
        _context = context;
    }
    
    // get comments of a post
    [HttpGet("{id:int}/comments")]
    public async Task<IActionResult> GetCommentsOfPost(int id)
    {
        var comments = await _context.Comments.Where(c => c.PostId == id).Select(c => new Comment
        {
            Id = c.Id,
            Text = c.Text,
            PostId = c.PostId,
            CreatedAt = c.CreatedAt,
        }).ToListAsync();

        return Ok(comments);
    }

    // Add comment to a post
    [HttpPost("{post_id:int}/comments")]
    public async Task<IActionResult> AddCommentToPost(int post_id, string comment)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == post_id);
        
        if (post == null) return NotFound();
        
        var newComment = new Comment
        {
            Text = comment,
            PostId = post_id,
            CreatedAt = DateTime.Now,
        };
        
        await _context.Comments.AddAsync(newComment);
        await _context.SaveChangesAsync();
        
        return Accepted();
    }
    
    // get single comment of a post
    [HttpGet("{post_id:int}/comments/{comment_id:int}")]
    public async Task<IActionResult> GetSingleCommentOfPost(int post_id, int comment_id)
    {
        var comment = await _context.Comments.Where(c => c.PostId == post_id && c.Id == comment_id).Select(c => new Comment
        {
            Id = c.Id,
            Text = c.Text,
            PostId = c.PostId,
            CreatedAt = c.CreatedAt,
        }).ToListAsync();

        return Ok(comment);
    }
    
    // edit comment of a post
    [HttpPut("{post_id:int}/comments/{comment_id:int}")]
    public async Task<IActionResult> EditCommentOfPost(int post_id, int comment_id, string editedComment)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.PostId == post_id && c.Id == comment_id);
        
        if (comment == null) return NotFound();

        comment.Text = editedComment;
        comment.CreatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // delete comment of a post
    [HttpDelete("{post_id:int}/comments/{comment_id:int}")]
    public async Task<IActionResult> DeleteCommentOfPost(int post_id, int comment_id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.PostId == post_id && c.Id == comment_id);

        if (comment == null) return NotFound();

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}