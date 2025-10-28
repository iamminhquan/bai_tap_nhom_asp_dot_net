using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using BaiTapNhom02_Lan_02.Database;

namespace BaiTapNhom02_Lan_02.Controllers
{
    public class AuthController(ConnectDatabase connectDatabase) : Controller
    {
        //private readonly string _connectionectionString = "Data Source=LAPTOP-5N7OU2IQ\\SQLEXPRESS;Initial Catalog=DemoLogin;Integrated Security=True;Trust Server Certificate=True";
        private readonly ConnectDatabase _connectDatabase = connectDatabase;

        // Nếu request == GET thì render ra trang giao diện.
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Else: xử lý logic login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Fake hased password.
            string hashedPassword = password;

            // Kết nối tới DB
            using SqlConnection connection = _connectDatabase.GetConnection();
            // Open connection.
            connection.Open();

            // Lấy ra email và mật khẩu
            string queryStaff = "SELECT * FROM Staffs WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";

            // thực thi truy vấn tới kết nối đã mở
            SqlCommand cmdStaff = new(queryStaff, connection);
            cmdStaff.Parameters.AddWithValue("@Email", email);
            cmdStaff.Parameters.AddWithValue("@HashedPassword", hashedPassword);

            // Đọc từng dữ liệu được trả về từ SQL
            SqlDataReader reader = cmdStaff.ExecuteReader();

            if (reader.Read())
            {
                int role = Convert.ToInt32(reader["Roles"]);
                string? username = reader["Username"].ToString();

                // Tạo session để lưu trữ phiên làm việc.
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", role.ToString());

                reader.Close();

                // Trả về form dành cho nhân viên
                // Ở đây, cả admin và nhân viên đều là nhân viên.
                if (role == 0)
                    return RedirectToAction("ProductManagement", "Home", new { area = "Admin" });
                else
                    return RedirectToAction("ProductManagement", "Home", new { area = "Admin" });
            }
            reader.Close();

            // Tương tự ở trên nhưng logic dành cho khách hàng
            string queryCustomer = "SELECT * FROM Customers WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";
            SqlCommand cmdCustomer = new(queryCustomer, connection);
            cmdCustomer.Parameters.AddWithValue("@Email", email);
            cmdCustomer.Parameters.AddWithValue("@HashedPassword", hashedPassword);

            SqlDataReader anotherReader = cmdCustomer.ExecuteReader();

            if (anotherReader.Read())
            {
                string? name = anotherReader["CustomerName"].ToString();
                HttpContext.Session.SetString("Username", name);
                HttpContext.Session.SetString("Role", "Customer");
                anotherReader.Close();
                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }
            anotherReader.Close();

            ViewBag.Error = "Email hoặc mật khẩu không đúng!";
            return View();
        }

        public IActionResult Logout()
        {
            // Destroy session.
            HttpContext.Session.Clear();

            // Return user to Index page.
            return RedirectToAction("Index", "Home");
        }
    }
}
