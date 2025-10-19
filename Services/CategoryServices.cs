using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;

namespace BaiTapNhom02_Lan_02.Services
{
    // thainguyen
    // them danh muc vao db khi dang them san pham 
    // 13/10/25 - 20h30p
    public class CategoryServices
    {
        private readonly ConnectDatabase _connectDatabase;
        public CategoryServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }

        public List<Categories> GetAllCategories() {
            var result = new List<Categories>();
            try
            {
                using (var connect = _connectDatabase.GetConnection())
                {
                    string query = "select * from Categories";
                    using (var commad = new SqlCommand(query, connect))
                    {
                        connect.Open();
                        using (var reader = commad.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapToCategory(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { 
                throw new Exception("Lỗi khi lấy danh mục sản phẩm", ex);
            }
            return result;
        }
        public bool AddCategory(Categories category)
        {
            try
            {
                using (var connection = _connectDatabase.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string queryCategory = @"INSERT INTO Categories
                        (CategoryName, States, Slug)
                        VALUES
                        (@CategoryName, @States, @Slug)";

                            using (var cmd = new SqlCommand(queryCategory, connection, transaction))
                            {
                                AddCommandCategory(cmd, category);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Lỗi khi thêm danh mục", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Categories MapToCategory(SqlDataReader reader)
        {
            return new Categories
            {
                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                CategoryName = reader["CategoryName"]?.ToString() ?? string.Empty,
                States = reader["States"] != DBNull.Value ? Convert.ToByte(reader["States"]) : (byte)1,
                Slug = reader["Slug"]?.ToString()
            };
        }

        private void AddCommandCategory(SqlCommand command, Categories category)
        {
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@States", category.States);
            command.Parameters.AddWithValue("@Slug", (object?)category.Slug ?? DBNull.Value);
        }

    }
}
