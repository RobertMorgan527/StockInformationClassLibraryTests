using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StockInformationClassLibrary
{
    public class QADatabase : IQADatabase
    {
        private readonly string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";

        public List<string> getUsernames()
        {
            string sql = $"Select username FROM data";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var usernames = new List<string>();
                foreach (var username in reader)
                {
                    usernames.Add(username.ToString());
                }
                return usernames;
            }
        }
        public List<string> getPasswords()
        {
            string sql = $"Select password FROM data";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var passwords = new List<string>();
                foreach (var password in reader)
                {
                    passwords.Add(password.ToString());
                }
                return passwords;
            }
        }
        public List<int> getCompanyIds()
        {
            string sql = $"Select companyIDs FROM data";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var companyIDs = new List<int>();
                foreach (var ID in reader)
                {
                    companyIDs.Add(Int32.Parse(ID.ToString()));
                }
                return companyIDs;
            }
        }
        public List<int> getStockLevels()
        {
            string sql = $"Select stockLevels FROM data";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                var stockLevels = new List<int>();
                foreach (var stockLevel in reader)
                {
                    stockLevels.Add(Int32.Parse(stockLevel.ToString()));
                }
                return stockLevels;
            }
        }
    }
}
