using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AdoDotNet
{
    public class DataUtility
    {
        private readonly string _connectionString;

        public DataUtility(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void WriteData(string sql, Dictionary<string, object>parameters)
        {
            using var sqlCommand = GetCommand(sql, parameters);

            sqlCommand.ExecuteNonQuery();
        }

        public List<Dictionary<string, object>> ReadData(string sql)
        {
            using var sqlCommand = GetCommand(sql);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var data = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader[i]);
                }
                //Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["EmployeeName"]}, Age: {reader["Age"]}, Date of Joining: {reader["DateOfJoining"]}, Salary: {reader["Salary"]}");
                data.Add(row);
            }
            return data;
        }

        private SqlCommand GetCommand(string sql, Dictionary<string, object>parameters)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            foreach (var parameter in parameters)
            {
                sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value)); // or we can write SqlCommand.Parametes.AddWithValue(parameter.Key, parameter.Value);
            }
            return sqlCommand;
        }

        private SqlCommand GetCommand(string sql)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand(sql, sqlConnection);
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }

            return sqlCommand;
        }
    }
}
