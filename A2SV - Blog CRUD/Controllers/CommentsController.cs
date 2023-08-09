using Microsoft.AspNetCore.Mvc;

namespace A2SV___Blog_CRUD.Controllers;

[Route("api/[controller]")]     // api/comments
[ApiController]
public class commentsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("Hello controller!!");
    }
}