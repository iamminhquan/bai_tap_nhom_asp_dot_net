using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Bill
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int StaffId { get; set; }

    public DateTime OrderDate { get; set; }

    public int TotalItems { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
