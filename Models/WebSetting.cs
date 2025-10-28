using System;
using System.Collections.Generic;

namespace BaiTapNhom02_Lan_02.Models;

public partial class WebSetting
{
    public int SettingId { get; set; }

    public string Logo { get; set; } = null!;

    public int MaxSizeImage { get; set; }

    public string? SettingDescription { get; set; }

    public string SettingUrl { get; set; } = null!;

    public string Header { get; set; } = null!;

    public string Footer { get; set; } = null!;
}
