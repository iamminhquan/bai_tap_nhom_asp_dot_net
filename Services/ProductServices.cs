using BaiTapNhom02_Lan_02.Database;
<<<<<<< HEAD
using Microsoft.Data.SqlClient;


=======
using BaiTapNhom02_Lan_02.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
>>>>>>> AnhNgonLuyen_AddProductFeature

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
                    string query = @"
                    SELECT 
                        p.ProductId, 
                        p.ProductName, 
                        p.Price, 
                        p.PromotionPrice, 
                        p.ProductDescription, 
                        p.TagName, 
                        p.CategoryId, 
                        p.States,
                        img.ImageUrl
                    FROM Products p
                    OUTER APPLY (
                        SELECT TOP 1 i.ImageUrl
                        FROM ProductImages i
                        WHERE i.ProductId = p.ProductId
                        ORDER BY i.SortOrder ASC
                    ) img
                    WHERE p.States = 1;
                    ";

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
                            string queryProduct = @"
                                INSERT INTO Products 
                                (ProductName, Price, PromotionPrice, ProductDescription, TagName, CategoryId, States)
                                VALUES (@ProductName, @Price, @PromotionPrice, @ProductDescription, @TagName, @CategoryId, @States);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                            int newProductId;
                            using (var cmd = new SqlCommand(queryProduct, connection, transaction))
                            {
                                AddCommandProduct(cmd, product);
                                newProductId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Nếu có ảnh thì thêm vào ProductImages
                            if (!string.IsNullOrEmpty(product.ImageUrl))
                            {
                                string queryImage = @"
                                    INSERT INTO ProductImages (ProductId, ImageUrl, SortOrder)
                                    VALUES (@ProductId, @ImageUrl, 0);";

                                using (var imageCmd = new SqlCommand(queryImage, connection, transaction))
                                {
                                    imageCmd.Parameters.AddWithValue("@ProductId", newProductId);
                                    imageCmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                                    imageCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                           
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Lỗi khi thêm sản phẩm", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối CSDL khi thêm sản phẩm", ex);
            }
            return false;
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
                ImageUrl = reader["ImageUrl"]?.ToString()
            };
        }

        // Gán parameter cho câu lệnh thêm sản phẩm
        private void AddCommandProduct(SqlCommand command, Product product)
        {
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@PromotionPrice", product.PromotionPrice);
            command.Parameters.AddWithValue("@ProductDescription", (object?)product.ProductDescription ?? DBNull.Value);
            command.Parameters.AddWithValue("@TagName", (object?)product.TagName ?? DBNull.Value);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@States", product.States);
        }

        // Các hàm chưa triển khai
        public void UpdateList(List<Product> list)
        {
            //_dsSanPham.Clear();
            //_dsSanPham.AddRange(list);
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
