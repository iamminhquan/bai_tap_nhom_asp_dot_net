using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Models;
using Microsoft.Data.SqlClient;

namespace BaiTapNhom02_Lan_02.Services
{

    //ThaiNguyen
    //Lay ra danh sach ten TagName 
    //22h10p
    public class TagNameServices
    {
        private readonly ConnectDatabase _connecDatabase;

        public TagNameServices(ConnectDatabase connecDatabase)
        {
            _connecDatabase = connecDatabase;
        }
        // Lấy tất cả sản phẩm
        public List<TagName> GetAllTagName()
        {
            var result = new List<TagName>();
            try
            {
                using (var connection = _connecDatabase.GetConnection())
                {
                  

                    string query = "SELECT * FROM TagName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapToTagName(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }

            return result;
        }
        private TagName MapToTagName(SqlDataReader reader)
        {
            return new TagName
            {
                TagId = Convert.ToInt32(reader["TagId"]),
                NameTag = reader["NameTag"]?.ToString()
            };
        }  
    }
}
