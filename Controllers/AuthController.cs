using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BaiTapNhom02_Lan_02.Controllers
{
    public class AuthController : Controller
    {
        private readonly string _connectionectionString = "Data Source=LAPTOP-5N7OU2IQ\\SQLEXPRESS;Initial Catalog=DemoLogin;Integrated Security=True;Trust Server Certificate=True";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Fake hased password.
            string hashedPassword = password;

            using (SqlConnection connection = new SqlConnection(_connectionectionString))
            {
                connection.Open();

                string queryStaff = "SELECT * FROM Staffs WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";
                SqlCommand cmdStaff = new SqlCommand(queryStaff, connection);
                cmdStaff.Parameters.AddWithValue("@Email", email);
                cmdStaff.Parameters.AddWithValue("@HashedPassword", hashedPassword);

                SqlDataReader reader = cmdStaff.ExecuteReader();

                if (reader.Read())
                {
                    int role = Convert.ToInt32(reader["Roles"]);
                    string? username = reader["Username"].ToString();

                    HttpContext.Session.SetString("Username", username);
                    HttpContext.Session.SetString("Role", role.ToString());

                    reader.Close();

                    if (role == 0)
                        return RedirectToAction("CreateProduct", "Product", new { area = "Admin" });
                    else
                        return RedirectToAction("CreateProduct", "Product", new { area = "Admin" });
                }
                reader.Close();

                string queryCustomer = "SELECT * FROM Customers WHERE Email = @Email AND HashedPassword = @HashedPassword AND States = 1";
                SqlCommand cmdCustomer = new SqlCommand(queryCustomer, connection);
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
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
