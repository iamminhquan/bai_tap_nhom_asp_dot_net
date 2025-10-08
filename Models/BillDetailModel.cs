namespace BaiTapNhom02_Lan_02.Models
{
    public class BillDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }           // FK to Orders
        public int ProductId { get; set; }         // FK to Products
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
