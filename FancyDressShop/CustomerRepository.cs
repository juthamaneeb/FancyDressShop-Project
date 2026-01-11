using FancyDressShop.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyDressShop
{
    public class CustomerRepository
    {
        private DBConnection dbConnection;
        public CustomerRepository()
        {
            dbConnection = new DBConnection();
        }

        public string IsDuplicate(Customer customer, bool isNewRegistration = true)
        {
            string excludeIdCondition = isNewRegistration ? "" : $" AND customer_id != {customer.CustomerId}";

            string query = $@"
                (SELECT 'Email' AS DuplicateField FROM customers WHERE email = @email AND email IS NOT NULL {excludeIdCondition} LIMIT 1)
                UNION ALL
                (SELECT 'เบอร์โทร' FROM customers WHERE phone_number = @phoneNumber AND phone_number IS NOT NULL {excludeIdCondition} LIMIT 1)
                UNION ALL
                (SELECT 'เลขบัญชี' FROM customers WHERE account_number = @accountNumber AND account_number IS NOT NULL {excludeIdCondition} LIMIT 1)
                LIMIT 1";

            string duplicateField = string.Empty;

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@email", !string.IsNullOrEmpty(customer.Email) ? (object)customer.Email : DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", !string.IsNullOrEmpty(customer.PhoneNumber) ? (object)customer.PhoneNumber : DBNull.Value);
                    cmd.Parameters.AddWithValue("@accountNumber", !string.IsNullOrEmpty(customer.AccountNumber) ? (object)customer.AccountNumber : DBNull.Value);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        duplicateField = result.ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error checking duplicates: " + ex.Message, "Error");
                    duplicateField = "Error";
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return duplicateField;
        }

        public bool RegisterCustomer(Customer customer)
        {
            string duplicateField = IsDuplicate(customer, isNewRegistration: true);

            if (!string.IsNullOrEmpty(duplicateField))
            {
                MessageBox.Show($"ไม่สามารถลงทะเบียนได้: {duplicateField} ถูกใช้ไปแล้ว", "ข้อมูลซ้ำซ้อน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string query = @"
                INSERT INTO customers (
                    username, password, full_name, email, 
                    phone_number, address, birth_date, profile_image, 
                    status, bank_name, account_number, account_name, role
                ) 
                VALUES (
                    @username, @password, @fullName, @email, 
                    @phoneNumber, @address, @birthDate, @profileImage, 
                    @status, @bankName, @accountNumber, @accountName, 'customer'
                )";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@username", customer.Username);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    cmd.Parameters.AddWithValue("@fullName", customer.FullName);

                    cmd.Parameters.AddWithValue("@address", (object)customer.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", (object)customer.PhoneNumber ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@email", (object)customer.Email ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@birthDate", customer.BirthDate.HasValue ? customer.BirthDate.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@profileImage", customer.ProfileImage ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@bankName", (object)customer.BankName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@accountNumber", (object)customer.AccountNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@accountName", (object)customer.AccountName ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@status", "Active");


                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool IsUsernameExists(string username, int currentCustomerId = 0)
        {
            string query = "SELECT COUNT(*) FROM customers WHERE username = @username";

            if (currentCustomerId > 0)
            {
                query += " AND customer_id != @currentCustomerId";
            }

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);
                    if (currentCustomerId > 0)
                    {
                        cmd.Parameters.AddWithValue("@currentCustomerId", currentCustomerId);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error checking username: " + ex.Message, "Error");
                    return true;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return true;
        }

        public Customer LoginCustomer(string username, string password)
        {
            string query = @"
        SELECT 
            customer_id, username, password, full_name, email, created_at,
            phone_number, address, birth_date, profile_image,
            bank_name, account_number, account_name,
            status, ban_reason, ban_until, role
        FROM customers
        WHERE username = @username AND password = @password";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    Customer loggedInCustomer = null;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loggedInCustomer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Username = reader.GetString("username"),
                                FullName = reader.GetString("full_name"),
                                CreatedAt = reader.GetDateTime("created_at"),

                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                                Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                ProfileImage = reader.IsDBNull(reader.GetOrdinal("profile_image")) ? null : reader.GetString("profile_image"),

                                BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_date")) ? (DateTime?)null : reader.GetDateTime("birth_date"),

                                Status = reader.GetString("status"),
                                BanReason = reader.IsDBNull(reader.GetOrdinal("ban_reason")) ? null : reader.GetString("ban_reason"),
                                BanUntil = reader.IsDBNull(reader.GetOrdinal("ban_until")) ? (DateTime?)null : reader.GetDateTime("ban_until"),
                            
                                BankName = reader.IsDBNull(reader.GetOrdinal("bank_name")) ? null : reader.GetString("bank_name"),
                                AccountNumber = reader.IsDBNull(reader.GetOrdinal("account_number")) ? null : reader.GetString("account_number"),
                                AccountName = reader.IsDBNull(reader.GetOrdinal("account_name")) ? null : reader.GetString("account_name"),
                            
                                Role = reader.GetString("role")
                            };
                        }
                    }

                    if (loggedInCustomer != null &&
                       (loggedInCustomer.Status == "Banned" || loggedInCustomer.Status == "Suspended"))
                    {
                        if (loggedInCustomer.BanUntil.HasValue && loggedInCustomer.BanUntil.Value <= DateTime.Now)
                        {
                            AutoUnbanCustomer(loggedInCustomer.CustomerId);

                            loggedInCustomer.Status = "Active";
                            loggedInCustomer.BanReason = null;
                            loggedInCustomer.BanUntil = null;
                        }
                    }

                    return loggedInCustomer;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return null;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            string query = @"
                    SELECT 
                        customer_id, username, password, full_name, email, created_at,
                        phone_number, address, birth_date, profile_image, 
                        bank_name, account_number, account_name,
                        status, ban_reason, ban_until
                    FROM customers";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerList.Add(new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                FullName = reader.GetString("full_name"),
                                PhoneNumber = reader.GetString("phone_number"),

                                Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_date")) ? DateTime.MinValue : reader.GetDateTime("birth_date"),
                                ProfileImage = reader.IsDBNull(reader.GetOrdinal("profile_image")) ? null : reader.GetString("profile_image"),

                                CreatedAt = reader.GetDateTime("created_at"),
                                Status = reader.GetString("status"),
                                BanReason = reader.IsDBNull(reader.GetOrdinal("ban_reason")) ? null : reader.GetString("ban_reason"),

                                BankName = reader.IsDBNull(reader.GetOrdinal("bank_name")) ? null : reader.GetString("bank_name"),
                                AccountNumber = reader.IsDBNull(reader.GetOrdinal("account_number")) ? null : reader.GetString("account_number"),
                                AccountName = reader.IsDBNull(reader.GetOrdinal("account_name")) ? null : reader.GetString("account_name"),

                                BanUntil = reader.IsDBNull(reader.GetOrdinal("ban_until")) ? (DateTime?)null : reader.GetDateTime("ban_until"),

                            });
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error getting customers: " + ex.Message, "Database Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return customerList;
        }

        public bool AddCustomer(Customer customer)
        {
            string query = @"
                INSERT INTO customers (
                    username, password, full_name, email, phone_number, address, 
                    birth_date, profile_image, status, ban_reason, ban_until, created_at
                ) 
                VALUES (
                    @username, @password, @fullName, @email, @phoneNumber, @address, 
                    @birthDate, @profileImage, @status, @banReason, @banUntil, NOW()
                )";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@username", customer.Username);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    cmd.Parameters.AddWithValue("@fullName", customer.FullName);
                    cmd.Parameters.AddWithValue("@email", (object)customer.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", (object)customer.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@address", (object)customer.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@birthDate", (object)customer.BirthDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@profileImage", (object)customer.ProfileImage ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", customer.Status);
                    cmd.Parameters.AddWithValue("@banReason", (object)customer.BanReason ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@banUntil", (object)customer.BanUntil ?? DBNull.Value); 

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error adding customer: " + ex.Message, "Database Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string duplicateField = IsDuplicate(customer, isNewRegistration: false);

            if (!string.IsNullOrEmpty(duplicateField))
            {
                MessageBox.Show($"ไม่สามารถแก้ไขข้อมูลได้: {duplicateField} ถูกใช้ไปแล้ว", "ข้อมูลซ้ำซ้อน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string query = @"
                UPDATE customers SET
                    username = @username,
                    full_name = @fullName, 
                    email = @email,
                    phone_number = @phoneNumber,
                    address = @address,
                    birth_date = @birthDate,
                    profile_image = @profileImage,
                    status = @status,
                    ban_reason = @banReason,
                    bank_name = @bankName,
                    account_number = @accountNumber,
                    account_name = @accountName,
                    ban_until = @banUntil";

            System.Text.StringBuilder updateQuery = new System.Text.StringBuilder(query);

            bool passwordIsChanging = !string.IsNullOrEmpty(customer.Password);

            if (passwordIsChanging)
            {
                updateQuery.Append(", password = @password");
            }

            updateQuery.Append(" WHERE customer_id = @customerId");

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(updateQuery.ToString(), dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@username", customer.Username);
                    cmd.Parameters.AddWithValue("@fullName", customer.FullName);
                    cmd.Parameters.AddWithValue("@email", (object)customer.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@phoneNumber", (object)customer.PhoneNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@address", (object)customer.Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@birthDate", (object)customer.BirthDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@profileImage", (object)customer.ProfileImage ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", customer.Status);
                    cmd.Parameters.AddWithValue("@banReason", (object)customer.BanReason ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@banUntil", (object)customer.BanUntil ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@bankName", (object)customer.BankName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@accountNumber", (object)customer.AccountNumber ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@accountName", (object)customer.AccountName ?? DBNull.Value);

                    if (passwordIsChanging)
                    {
                        cmd.Parameters.AddWithValue("@password", customer.Password);
                    }

                    cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error updating customer: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }


        public bool DeleteCustomer(int customerId)
        {
            string query = "DELETE FROM customers WHERE customer_id = @customerId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error deleting customer: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public List<Customer> SearchCustomers(string searchTerm)
        {
            List<Customer> customerList = new List<Customer>();
            string searchPattern = $"%{searchTerm}%";

            string query = @"
                SELECT 
                    customer_id, username, password, full_name, email, phone_number, 
                    address, birth_date, profile_image, status, ban_reason, ban_until,
                    bank_name, account_number, account_name, created_at
                FROM 
                    customers 
                WHERE 
                    full_name LIKE @searchPattern OR
                    CAST(customer_id AS CHAR) LIKE @searchPattern OR
                    email LIKE @searchPattern OR
                    phone_number LIKE @searchPattern OR
                    username LIKE @searchPattern";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@searchPattern", searchPattern);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                FullName = reader.GetString("full_name"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                                Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                                BankName = reader.IsDBNull(reader.GetOrdinal("bank_name")) ? null : reader.GetString("bank_name"),
                                AccountNumber = reader.IsDBNull(reader.GetOrdinal("account_number")) ? null : reader.GetString("account_number"),
                                AccountName = reader.IsDBNull(reader.GetOrdinal("account_name")) ? null : reader.GetString("account_name"),
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_date")) ? (DateTime?)null : reader.GetDateTime("birth_date"),
                                ProfileImage = reader.IsDBNull(reader.GetOrdinal("profile_image")) ? null : reader.GetString("profile_image"),
                                Status = reader.GetString("status"),
                                BanReason = reader.IsDBNull(reader.GetOrdinal("ban_reason")) ? null : reader.GetString("ban_reason"),
                                BanUntil = reader.IsDBNull(reader.GetOrdinal("ban_until")) ? (DateTime?)null : reader.GetDateTime("ban_until"),
                                CreatedAt = reader.GetDateTime("created_at")
                            };
                            customerList.Add(customer);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error searching customers: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return customerList;
        }

        public Customer GetCustomerByUsername(string username)
        {
            Customer customer = null;

            string query = "SELECT customer_id, username, full_name, role FROM customers WHERE username = @username";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Username = reader.GetString("username"),
                                FullName = reader.GetString("full_name"),
                                Role = reader.GetString("role")

                            };
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error getting customer details: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return customer;
        }

        public int VerifyCustomerForReset(string username, string contact)
        {
            string query = @"
        SELECT customer_id FROM customers 
        WHERE username = @username 
        AND (email = @contact OR phone_number = @contact)"; 

            int customerId = 0;
            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@contact", contact);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        customerId = Convert.ToInt32(result);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return customerId;
        }

        public bool UpdatePassword(int customerId, string newPassword)
        {
            string query = "UPDATE customers SET password = @newPassword WHERE customer_id = @id";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@id", customerId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            string query = @"
                SELECT 
                    customer_id, username, full_name, email, phone_number, address,
                    bank_name, account_number, account_name, status, ban_reason, ban_until, 
                    role, created_at, profile_image, birth_date
                FROM customers
                WHERE customer_id = @customerId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerId = reader.GetInt32("customer_id"),
                                Username = reader.GetString("username"),
                                FullName = reader.GetString("full_name"),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("phone_number")) ? null : reader.GetString("phone_number"),
                                Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString("address"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),

                                BankName = reader.IsDBNull(reader.GetOrdinal("bank_name")) ? null : reader.GetString("bank_name"),
                                AccountNumber = reader.IsDBNull(reader.GetOrdinal("account_number")) ? null : reader.GetString("account_number"),
                                AccountName = reader.IsDBNull(reader.GetOrdinal("account_name")) ? null : reader.GetString("account_name"),

                                Status = reader.GetString("status"),
                                Role = reader.GetString("role"),
                                CreatedAt = reader.GetDateTime("created_at"),
                                ProfileImage = reader.IsDBNull(reader.GetOrdinal("profile_image")) ? null : reader.GetString("profile_image"),
                                BirthDate = reader.IsDBNull(reader.GetOrdinal("birth_date")) ? (DateTime?)null : reader.GetDateTime("birth_date"),
                                BanReason = reader.IsDBNull(reader.GetOrdinal("ban_reason")) ? null : reader.GetString("ban_reason"),
                                BanUntil = reader.IsDBNull(reader.GetOrdinal("ban_until")) ? (DateTime?)null : reader.GetDateTime("ban_until"),
                            };
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error getting Customer by ID: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }

            return customer;
        }

        private void AutoUnbanCustomer(int customerId)
        {
            string query = @"
                UPDATE customers 
                SET 
                    status = 'Active',
                    ban_reason = NULL,
                    ban_until = NULL
                WHERE 
                    customer_id = @customerId";

            using (DBConnection tempDbConnection = new DBConnection())
            {
                if (tempDbConnection.OpenConnection())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, tempDbConnection.GetConnection());
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Auto-Unban Failed for Customer ID {customerId}: {ex.Message}");
                    }
                    finally
                    {
                        tempDbConnection.CloseConnection();
                    }
                }
            }
        }
    }
}
