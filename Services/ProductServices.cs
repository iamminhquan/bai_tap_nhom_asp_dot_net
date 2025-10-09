using BaiTapNhom02_Lan_02.Database;
using BaiTapNhom02_Lan_02.Models;
using Microsoft.Data.SqlClient;


// Thái Nguyên
// chinh sua lai toan bo ProductService.cs 
// Ngày chỉnh sửa: 09/10/2025 - 21h50p
namespace BaiTapNhom02_Lan_02.Services
{
    public class ProductServices
    {
        private readonly ConnectDatabase _connectDatabase;

        public ProductServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            var result = new List<Product>();
            try
            {
                using (var connection = _connectDatabase.GetConnection())
                {
                    // Thái Nguyên
                    // chỉnh sửa lại query 
                    // Ngày chỉnh sửa: 09/10/2025 - 21h35P

                    string query = "SELECT * FROM Products";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapToProduct(reader));
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

        // Thêm sản phẩm mới
        public bool AddProduct(Product product)
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
                            // Thái Nguyên
                            // chỉnh sửa lại query 
                            // Ngày chỉnh sửa: 09/10/2025 - 21h35p

                            string queryProduct = @"INSERT INTO Products
                                (ProductName, ImageUrl, Price, PromotionPrice, ProductDescription, TagName, CategoryId, States, ProductType)
                                VALUES
                                (@ProductName, @ImageUrl, @Price, @PromotionPrice, @ProductDescription, @TagName, @CategoryId, @States, @ProductType)";

                            using (var cmd = new SqlCommand(queryProduct, connection, transaction))
                            {
                                AddCommandProduct(cmd, product);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Lỗi khi thêm sản phẩm", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối CSDL khi thêm sản phẩm", ex);
            }
        }

        // Map dữ liệu từ SqlDataReader sang Product
        private Product MapToProduct(SqlDataReader reader)
        {
            return new Product
            {
                ProductId = Convert.ToInt32(reader["ProductId"]),
                ProductName = reader["ProductName"]?.ToString(),
                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0,
                PromotionPrice = reader["PromotionPrice"] != DBNull.Value ? Convert.ToDecimal(reader["PromotionPrice"]) : 0,
                ProductDescription = reader["ProductDescription"]?.ToString(),
                TagName = reader["TagName"]?.ToString(),
                CategoryId = reader["CategoryId"] != DBNull.Value ? Convert.ToInt32(reader["CategoryId"]) : 0,
                States = reader["States"] != DBNull.Value ? Convert.ToInt32(reader["States"]) : 0,
                ImageUrl = reader["ImageUrl"]?.ToString(),
                ProductType = reader["ProductType"]?.ToString()
            };
        }

        // Gán parameter cho câu lệnh thêm sản phẩm
        private void AddCommandProduct(SqlCommand command, Product product)
        {
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@ImageUrl", (object?)product.ImageUrl ?? DBNull.Value);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@PromotionPrice", product.PromotionPrice);
            command.Parameters.AddWithValue("@ProductDescription", (object?)product.ProductDescription ?? DBNull.Value);
            command.Parameters.AddWithValue("@TagName", (object?)product.TagName ?? DBNull.Value);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@States", product.States);
            command.Parameters.AddWithValue("@ProductType", (object?)product.ProductType ?? DBNull.Value);
        }

        // Các hàm chưa yeu cau
        public void UpdateList(List<Product> list)
        {
        }

        public Product? GetById(int id)
        {
            return null;
        }

        public List<Product> Search(string keyword)
        {
            return null;
        }

        public void Update(Product sp) { }

        public void Delete(int id) { }

        public List<Product> GetKhuyenMai()
        {
            return null;
        }
    }
}