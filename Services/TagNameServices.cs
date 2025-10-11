using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Models;
using Microsoft.Data.SqlClient;

namespace BaiTapNhom02_Lan_02.Services
{
    //ThaiNguyen
    //Lay ra danh sach ten TagName 
    //22h10p
    public class TagNameServices(ConnectDatabase connecDatabase)
    {
        // Minh Quân
        // Thay default contructor bằng primary constructor.
        // Ngày thay đồi: 10/10/2025 - 2:09 AM.
        private readonly ConnectDatabase _connecDatabase = connecDatabase;

        // Lấy tất cả sản phẩm
        public List<Tags> GetAllTagName()
        {
            var result = new List<Tags>();
            try
            {
                using (var connection = _connecDatabase.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Tags";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapToTagName(reader));
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }

            return result;
        }

        private Tags MapToTagName(SqlDataReader reader)
        {
            return new Tags
            {
                TagId = Convert.ToInt32(reader["TagId"]),
                TagName = reader["TagName"]?.ToString()
            };
        }
    }
}
