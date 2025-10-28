using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using BaiTapNhom02_Lan_02.Models;
using BaiTapNhom02_Lan_02.Data;

namespace BaiTapNhom02_Lan_02.Controllers
{
    public class AuthController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Minh Quân
        // Thay thế đối tượng kết nối bằng AppDbContext.
        // Ngày chỉnh sửa: 28/10/2025 - 01:09 PM.
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Fake hashed password.
            string hashedPassword = password;

            // Find staff who has valid email and password.
            var staff = _context.Staffs
                .FirstOrDefault(s => s.Email == email
                                  && s.HashedPassword == hashedPassword
                                  && s.States == 1);

            if (staff != null)
            {
                byte? role = staff.Roles;
                string username = staff.Username ?? "Unknown";

                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Role", role.ToString());

                // Redirect to correct page.
                if (role == 0)
                    return RedirectToAction("ProductManagement", "Home", new { area = "Admin" });
                else
                    return RedirectToAction("ProductManagement", "Home", new { area = "Admin" });
            }

            // If not staff, try customer.
            var customer = _context.Customers
                .FirstOrDefault(c => c.Email == email
                                  && c.HashedPassword == hashedPassword
                                  && c.States == 1);

            if (customer != null)
            {
                string name = customer.CustomerName ?? "Customer";
                HttpContext.Session.SetString("Username", name);
                HttpContext.Session.SetString("Role", "Customer");

                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }

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
