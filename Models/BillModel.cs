namespace BaiTapNhom02_Lan_02.Models
{
    public class Bills
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }     // FK to Products
        public int CustomerId { get; set; }    // FK to Customers
        public int StaffId { get; set; }       // FK to Staffs
        public DateTime OrderDate { get; set; }
        public int TotalItems { get; set; }    // Total quantity
        public decimal TotalAmount { get; set; } // Total payment
    }
}
