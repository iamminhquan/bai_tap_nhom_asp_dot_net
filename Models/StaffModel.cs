namespace BaiTapNhom02_Lan_02.Models
{
    public class Staffs
    {
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public string? AccountName { get; set; }
        public string? AccountPassword { get; set; }
        public string? StaffAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public byte States { get; set; }   // 0 = Inactive, 1 = Active
        public byte Roles { get; set; }    // 0 = Staff, 1 = Admin
    }
}
