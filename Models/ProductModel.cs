namespace BaiTapNhom02_Lan_02.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public string? ProductDescription { get; set; }
        public string? TagName { get; set; }
        public int CategoryId { get; set; }          // FK to Categories
        public string? ProductType { get; set; }     // Kiểu NVARCHAR(255)
        public int States { get; set; }
        public string? ImageUrl { get; set; }        // từ bảng ProductImages
    }
}
