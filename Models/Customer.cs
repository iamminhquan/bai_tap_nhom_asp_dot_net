using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public byte? States { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
