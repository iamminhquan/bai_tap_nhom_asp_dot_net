namespace BaiTapNhom02_Lan_02.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerUsername { get; set; }
        public string? CustomerPassword { get; set; }
        public string? CustomerAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public byte States { get; set; }    // 0 = Inactive, 1 = Active
    }
}
