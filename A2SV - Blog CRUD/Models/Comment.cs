using System;
using System.Collections.Generic;

namespace A2SV___Blog_CRUD.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? PostId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Post? Post { get; set; }
}
