using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal PromotionPrice { get; set; }

    public string? ProductDescription { get; set; }

    public string? TagName { get; set; }

    public int CategoryId { get; set; }

    public byte States { get; set; }

    public string ProductType { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
