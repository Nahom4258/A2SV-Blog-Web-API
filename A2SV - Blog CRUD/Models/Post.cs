using System;
using System.Collections.Generic;

namespace A2SV___Blog_CRUD.Models;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
