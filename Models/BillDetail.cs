using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class BillDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal PromotionPrice { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Bill Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
