using BaiTapNhom02_Lan_02.Database;
using System.Data.SqlClient;



namespace BaiTapNhom02_Lan_02.Services
{
    public class ProductServices
    {
        private readonly ConnectDatabase _connectDatabase;

        public ProductServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }

        // add product into database 
        //public bool AddProduct(string productName)
        //{

        //    try
        //    {
        //        using (var connection = _connectDatabase.GetConnection()) // viet ham GetConnection o Database/ConnectDatabase.cs
        //        {
        //            connection.Open();

        //            string queryInsertProdut = @"Insert into Products(ProductName) 
        //                                     Values(@ProductName) ";
        //            using (var command = connection.CreateCommand())
        //            {
        //                command.CommandText = queryInsertProdut;
        //                command.Parameters.AddWithValue("@ProductName", productName);

        //                int rowsAffected = command.ExecuteNonQuery();
        //                return rowsAffected > 0;
        //            }
        //        }
        //    }
        //    catch (Exception )
        //    {
        //        return false;
        //    }

        //}
    }
}
