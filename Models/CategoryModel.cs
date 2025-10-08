using Humanizer;

namespace BaiTapNhom02_Lan_02.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int ParentIdId { get; set; }
        public int States { get; set; } // 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
        public string? Slug { get; set; }
    }
}
