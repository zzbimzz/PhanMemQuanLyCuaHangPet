using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;
        // thiết kế mẫu singletonlà một mẫu thiết kế cho phép chỉ có một đối tượng duy nhất được tạo ra từ một lớp và
        // cung cấp một cách để truy cập đến đối tượng này từ bất kỳ nơi nào trong mã nguồn.
        public static DataProvider Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        private DataProvider() { }

        // sử dụng ADO.net
        static readonly string connectionStr = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=PhanMemQuanLyCuaHangPet;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable dt = new DataTable(); // tạo data chứa dữ liệu trả về từ truy vấn

            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' '); // phân tách cách phần tử thành khoảng trắng
                    int i = 0;
                    foreach (string param in listPara)
                    {
                        if (param.Contains('@'))  // kiểm tra có phần tử có chứa ký tự @ 
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]); // nếu có tham số truyền vào thì sẽ vào add
                            i++;
                        }
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd); // truy vấn và lấy dữ liệu
                da.Fill(dt);
                conn.Close();
                da.Dispose();
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int dt = 0;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string param in listPara)
                    {
                        if (param.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(param, parameters[i]);
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteNonQuery();

                conn.Close();
            }
            return dt;
        }
    }
}
