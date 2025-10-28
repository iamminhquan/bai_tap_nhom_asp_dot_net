using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public int? ParentId { get; set; }

    public string Content { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DateTimes { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Customer? User { get; set; }
}
