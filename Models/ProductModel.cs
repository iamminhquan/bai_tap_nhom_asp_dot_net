namespace BaiTapNhom02_Lan_02.Database.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? TagName { get; set; }
        public int CategoryId { get; set; }
        public int States { get; set; }
        public string? ImageUrl { get; set; } // từ bảng ProductImages
    }
}
