using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Poods
{
    class DataBaseHelper
    {
        private readonly string connectionString = "Server=localhost;Database=ff;User ID=root;Password=alexgame931!;SslMode=None;";
        public DataTable GetData(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                return dt;
            }
        }
        public object ExecuteScalar(MySqlCommand cmd)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    return cmd.ExecuteScalar(); // ✅ фикс: вызываем метод команды, а не свой
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    return null;
                }
            }
        }

        public DataTable GetData2(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Добавляем параметры
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                return dt;
            }
        }
        public DataTable GetMaterials()
        {
            return GetData("SELECT IdMaterials, MaterialName FROM materials");
        }
        public bool ExecuteQuery(MySqlCommand cmd)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    return false;
                }
            }
        }
        public List<string> GetEnumValues(string query)
        {
            List<string> positions = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    string enumValues = cmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(enumValues))
                    {
                        var values = enumValues
                            .Replace("enum(", "")
                            .Replace(")", "")
                            .Split(',')
                            .Select(x => x.Trim('\''))
                            .ToList();

                        positions.AddRange(values);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при получении значений enum: " + ex.Message);
                }
            }

            return positions;
        }
        public bool CheckLogin(string login, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM staff WHERE Login = @login AND Password = @password AND StatusOfAccount = 'Активен'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    return false;
                }
            }
        }
        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    return -1;
                }
            }
        }
        public void UpdateLastAuthDate(string login)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE staff SET LastDateOfAuthorization = @date WHERE Login = @login";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при обновлении даты авторизации: " + ex.Message);
                }
            }
        }
        public int CreateOrder(string orderNumber, int clientId, decimal totalCost, int? staffId = null)
        {
            string query = @"INSERT INTO `order`(OrderNumber, DateOrder, CompletionDate, Paid, Status, IdStaff, IdClient, TotalCost)
        VALUES (@orderNumber, @dateOrder, NULL, 'Неоплачен', 'Новый', @staffId, @clientId, @totalCost);
        SELECT LAST_INSERT_ID();";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                        cmd.Parameters.AddWithValue("@dateOrder", DateTime.Now);
                        cmd.Parameters.AddWithValue("@staffId", staffId.HasValue ? (object)staffId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                        cmd.Parameters.AddWithValue("@totalCost", totalCost);

                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Логируем конкретную ошибку MySQL
                Console.WriteLine($"MySQL Error {ex.Number}: {ex.Message}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании заказа: " + ex.Message);
                return -1;
            }
        }

        public bool AddOrderDetail(int orderId, int articleNum)
        {
            string query = @"
        INSERT INTO orderdetails (IdOrder, ArticleNum)
        VALUES (@orderId, @articleNum)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@articleNum", articleNum);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error {ex.Number} при добавлении детали: {ex.Message}");
                return false;
            }
        }
    }
}
