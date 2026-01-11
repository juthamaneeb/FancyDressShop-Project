using FancyDressShop.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace FancyDressShop.Repositories
{
    public class FancyDressRepository
    {
        private DBConnection dbConnection;

        public FancyDressRepository()
        {
            dbConnection = new DBConnection(); 
        }

        public List<FancyDress> GetAllDressesForAdmin()
        {
            List<FancyDress> dresses = new List<FancyDress>();
            string query = "SELECT * FROM dresses ORDER BY dress_id DESC";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                try
                {
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            FancyDress dress = new FancyDress();
                            dress.DressId = dataReader.GetInt32("dress_id");
                            dress.Name = dataReader.GetString("name");
                            dress.Description = dataReader.IsDBNull(dataReader.GetOrdinal("description")) ? null : dataReader.GetString("description");
                            dress.Category = dataReader.GetString("category");
                            dress.RentalPricePerDay = dataReader.GetDecimal("rental_price_per_day");
                            dress.DepositPrice = dataReader.GetDecimal("deposit_price");
                            dress.ImagePath = dataReader.IsDBNull(dataReader.GetOrdinal("image_path")) ? null : dataReader.GetString("image_path");
                            dress.Status = dataReader.IsDBNull(dataReader.GetOrdinal("status")) ? "Unavailable" : dataReader.GetString("status");

                            dresses.Add(dress);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting admin dresses: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return dresses;
        }

        public List<FancyDress> GetAllDresses()
        {
            List<FancyDress> dresses = new List<FancyDress>();
            string query = @"
                SELECT d.* 
                FROM dresses d
                WHERE d.status = 'Available'
                AND EXISTS (
                    SELECT 1 
                    FROM dress_inventory di 
                    WHERE di.dress_id = d.dress_id AND di.available_quantity > 0
                )";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                try
                {
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            FancyDress dress = new FancyDress();
                            dress.DressId = dataReader.GetInt32("dress_id");
                            dress.Name = dataReader.GetString("name");
                            dress.Description = dataReader.IsDBNull(dataReader.GetOrdinal("description")) ? null : dataReader.GetString("description");
                            dress.Category = dataReader.GetString("category");
                            dress.RentalPricePerDay = dataReader.GetDecimal("rental_price_per_day");
                            dress.DepositPrice = dataReader.GetDecimal("deposit_price");
                            dress.ImagePath = dataReader.IsDBNull(dataReader.GetOrdinal("image_path")) ? null : dataReader.GetString("image_path");
                            dress.Status = dataReader.IsDBNull(dataReader.GetOrdinal("status")) ? "Unavailable" : dataReader.GetString("status");

                            dresses.Add(dress);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error getting all dresses: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return dresses;
        }

        public FancyDress GetDressById(int dressId)
        {
            FancyDress foundDress = null;
            string query = "SELECT * FROM dresses WHERE dress_id = @dressId";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@dressId", dressId);

                try
                {
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            foundDress = new FancyDress();
                            foundDress.DressId = dataReader.GetInt32("dress_id");
                            foundDress.Name = dataReader.GetString("name");
                            foundDress.Description = dataReader.IsDBNull(dataReader.GetOrdinal("description")) ? null : dataReader.GetString("description");
                            foundDress.Category = dataReader.GetString("category");
                            foundDress.RentalPricePerDay = dataReader.GetDecimal("rental_price_per_day");
                            foundDress.DepositPrice = dataReader.GetDecimal("deposit_price");
                            foundDress.ImagePath = dataReader.IsDBNull(dataReader.GetOrdinal("image_path")) ? null : dataReader.GetString("image_path");
                            foundDress.Status = dataReader.IsDBNull(dataReader.GetOrdinal("status")) ? "Unavailable" : dataReader.GetString("status");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error getting dress by ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return foundDress;
        }


        public int AddDress(FancyDress dress)
        {
            string query = "INSERT INTO dresses (name, description, category, rental_price_per_day, deposit_price, image_path, status) " +
                           "VALUES (@name, @description, @category, @rentalPrice, @depositPrice, @imagePath, @status);" +
                           "SELECT LAST_INSERT_ID();";


            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@name", dress.Name);
                cmd.Parameters.AddWithValue("@description", dress.Description);
                cmd.Parameters.AddWithValue("@category", dress.Category);
                cmd.Parameters.AddWithValue("@rentalPrice", dress.RentalPricePerDay);
                cmd.Parameters.AddWithValue("@depositPrice", dress.DepositPrice);
                cmd.Parameters.AddWithValue("@imagePath", dress.ImagePath);
                cmd.Parameters.AddWithValue("@status", dress.Status);

                try
                {
                    int newDressId = Convert.ToInt32(cmd.ExecuteScalar());
                    return newDressId;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error adding dress: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return -1;
        }

        public bool UpdateDress(FancyDress dress)
        {
            string query = "UPDATE dresses SET name=@name, description=@description, category=@category, rental_price_per_day=@rentalPrice, deposit_price=@depositPrice, image_path=@imagePath, status=@status WHERE dress_id=@dressId";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                cmd.Parameters.AddWithValue("@dressId", dress.DressId);
                cmd.Parameters.AddWithValue("@name", dress.Name);
                cmd.Parameters.AddWithValue("@description", (object)dress.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@category", (object)dress.Category ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rentalPrice", dress.RentalPricePerDay);
                cmd.Parameters.AddWithValue("@depositPrice", dress.DepositPrice);
                cmd.Parameters.AddWithValue("@imagePath", (object)dress.ImagePath ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@status", dress.Status);


                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error updating dress: " + ex.Message);
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool DeleteDress(int dressId)
        {
            string query = "UPDATE dresses SET status = 'Unavailable' WHERE dress_id=@dressId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@dressId", dressId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error archiving dress: " + ex.Message);
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public List<FancyDress> SearchDresses(string searchTerm, string categoryFilter = "All")
        {
            List<FancyDress> dressList = new List<FancyDress>();
            string searchPattern = $"%{searchTerm}%";

            string query = @"
                SELECT d.* 
                FROM dresses d
                WHERE d.status = 'Available'
                AND EXISTS (
                    SELECT 1 
                    FROM dress_inventory di 
                    WHERE di.dress_id = d.dress_id AND di.available_quantity > 0
                )";

            if (categoryFilter != "All")
            {
                query += " AND category = @CategoryFilter ";
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " AND name LIKE @searchPattern "; 
            }

            query += " ORDER BY name"; 

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@searchPattern", searchPattern);

                    if (categoryFilter != "All")
                    {
                        cmd.Parameters.AddWithValue("@CategoryFilter", categoryFilter);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FancyDress dress = new FancyDress
                            {
                                DressId = reader.GetInt32("dress_id"),
                                Name = reader.GetString("name"),
                                Description = reader.GetString("description"),
                                Category = reader.GetString("category"),
                                Status = reader.GetString("status"),
                                RentalPricePerDay = reader.GetDecimal("rental_price_per_day"),
                                DepositPrice = reader.GetDecimal("deposit_price"),
                                ImagePath = reader.IsDBNull(reader.GetOrdinal("image_path")) ? null : reader.GetString("image_path")
                            };
                            dressList.Add(dress);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error searching dresses: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return dressList;
        }

        public List<FancyDress> GetRelatedDresses(int currentDressId, string category)
        {
            var relatedDresses = new List<FancyDress>();
            string sql = @"
        SELECT 
            dress_id, name, rental_price_per_day, image_path 
        FROM 
            dresses 
        WHERE 
            category = @Category AND dress_id != @currentId
        LIMIT 4";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(sql, dbConnection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@currentId", currentDressId);
                        command.Parameters.AddWithValue("@Category", category);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                relatedDresses.Add(new FancyDress
                                {
                                    DressId = reader.GetInt32("dress_id"),
                                    Name = reader.GetString("name"),
                                    RentalPricePerDay = reader.GetDecimal("rental_price_per_day"),
                                    ImagePath = reader.GetString("image_path")
                                });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error getting related dresses: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return relatedDresses;
        }

        public CartItem GetDressInventoryDetail(int inventoryId, int quantity)
        {
            CartItem item = null;

            string query = @"
        SELECT 
            d.name AS DressName, 
            d.rental_price_per_day, 
            d.deposit_price, 
            d.image_path, 
            inv.size AS DressSize
        FROM 
            dress_inventory inv
        JOIN 
            dresses d ON inv.dress_id = d.dress_id
        WHERE inv.inventory_id = @InventoryId";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item = new CartItem
                            {
                                DressInventoryId = inventoryId,
                                DressName = reader.GetString("DressName"),
                                DressSize = reader.GetString("DressSize"),
                                Quantity = quantity,

                                RentalPricePerDay = reader.GetDecimal("rental_price_per_day"),
                                DepositPrice = reader.GetDecimal("deposit_price"),
                                ImagePath = reader.IsDBNull(reader.GetOrdinal("image_path")) ? null : reader.GetString("image_path")
                            };
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error fetching dress inventory detail: " + ex.Message, "Database Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return item;
        }

        public CartItem GetCartItemDetailByInventoryId(int inventoryId, int quantity)
        {
            string query = @"
                SELECT 
                    d.dress_id, d.name AS DressName, d.rental_price_per_day, d.deposit_price, d.image_path,
                    di.size AS DressSize,
                    di.available_quantity
                FROM dress_inventory di
                JOIN dresses d ON di.dress_id = d.dress_id
                WHERE di.inventory_id = @inventoryId";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CartItem
                            {
                                DressInventoryId = inventoryId,
                                Quantity = quantity,
                                DressName = reader.GetString("DressName"),
                                RentalPricePerDay = reader.GetDecimal("rental_price_per_day"),
                                DepositPrice = reader.GetDecimal("deposit_price"),
                                ImagePath = reader.GetString("image_path"),
                                DressSize = reader.GetString("DressSize"),

                                MaxAvailableQuantity = reader.GetInt32("available_quantity")
                            };
                        }
                        return null;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error fetching cart item detail: " + ex.Message, "Database Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return null;
        }

        public List<string> GetAllCategoriesFromDresses()
        {
            List<string> categories = new List<string>();
            string query = "SELECT DISTINCT category FROM dresses ORDER BY category";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                categories.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading categories from dresses table: " + ex.Message, "DB Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return categories;
        }
    }
}
