using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class Staff
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string StaffAddress { get; set; } = null!;

    public byte Roles { get; set; }

    public byte? States { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
