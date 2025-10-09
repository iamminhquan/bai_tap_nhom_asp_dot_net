using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BaiTapNhom02_Lan_02.Database
{
    public class ConnectDatabase
    {
<<<<<<< HEAD
        private readonly string? _connectionString;
=======
        private readonly string _connectionString;
>>>>>>> AnhNgonLuyen_AddProductFeature

        public ConnectDatabase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}