using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace FancyDressShop
{
    public class DBConnection : IDisposable
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "fancydressshop";
            uid = "root";     
            password = "";   

            string connectionString;
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Connection Error: " + ex.Message, "Database Error");
                    return false;
                }
            }

            return true;
        }

        public bool CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Close Connection Error: " + ex.Message, "Database Error");
                    return false;
                }
            }
            return true;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
