using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public byte States { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
