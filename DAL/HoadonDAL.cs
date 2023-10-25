using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace DAL
{
    public class HoadonDAL
    {
        private string connectionString;

        public HoaDonDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connect");
        }

        public HoaDon GetHoadonByID(int maHoaDon)
        {
            HoaDon hoadon = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_hoadon_get_by_id", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaHoaDon", maHoaDon));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string jsonResult = reader.GetString(0);
                            hoadon = JsonSerializer.Deserialize<HoaDon>(jsonResult);
                        }
                    }
                }
            }

            return hoadon;
        }
    }
}
