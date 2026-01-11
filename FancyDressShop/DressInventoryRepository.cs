using MySql.Data.MySqlClient;
using FancyDressShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace FancyDressShop
{
    public class DressInventoryRepository
    {
        private DBConnection dbConnection;

        public DressInventoryRepository()
        {
            dbConnection = new DBConnection();
        }

        public List<DressInventory> GetInventoryByDressId(int dressId)
        {
            List<DressInventory> inventoryList = new List<DressInventory>();
            string query = "SELECT inventory_id, size, total_quantity, available_quantity FROM dress_inventory WHERE dress_id = @id";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@id", dressId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inventoryList.Add(new DressInventory
                            {
                                InventoryId = reader.GetInt32("inventory_id"),
                                DressId = dressId,
                                Size = reader.GetString("size"),
                                TotalQuantity = reader.GetInt32("total_quantity"),
                                AvailableQuantity = reader.GetInt32("available_quantity")
                            });
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error getting inventory: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return inventoryList;
        }


        public bool AddDressInventory(DressInventory inventory)
        {
            string query = @"
            INSERT INTO dress_inventory 
            (dress_id, size, total_quantity, available_quantity) 
            VALUES (@dressId, @size, @totalQuantity, @totalQuantity)";

            if (dbConnection.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                cmd.Parameters.AddWithValue("@dressId", inventory.DressId);
                cmd.Parameters.AddWithValue("@size", inventory.Size);
                cmd.Parameters.AddWithValue("@totalQuantity", inventory.TotalQuantity);


                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มไซส์: " + ex.Message);
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }


        public bool DeleteInventory(int inventoryId)
        {
            string deleteQuery = "DELETE FROM dress_inventory WHERE inventory_id = @inventoryId";

            if (dbConnection.OpenConnection())
            {
                MySqlConnection conn = dbConnection.GetConnection();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1451)
                    {
                        string softDeleteQuery = "UPDATE dress_inventory SET total_quantity = 0, available_quantity = 0 WHERE inventory_id = @inventoryId";
                        try
                        {
                            MySqlCommand cmdSoft = new MySqlCommand(softDeleteQuery, conn);
                            cmdSoft.Parameters.AddWithValue("@inventoryId", inventoryId);
                            cmdSoft.ExecuteNonQuery();

                            MessageBox.Show("ไซส์นี้มีประวัติการเช่าอยู่ ไม่สามารถลบออกจากฐานข้อมูลได้\nระบบได้ปรับจำนวนสินค้าเป็น 0 เพื่อปิดการใช้งานแทน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show("Error disabling inventory: " + ex2.Message);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error deleting inventory: " + ex.Message);
                        return false;
                    }
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool UpdateDressInventory(DressInventory inventory)
        {
            string query = @"
                UPDATE dress_inventory SET 
                    total_quantity = @totalQuantity, 
                    available_quantity = @availableQuantity 
                WHERE inventory_id = @inventoryId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                    cmd.Parameters.AddWithValue("@inventoryId", inventory.InventoryId);
                    cmd.Parameters.AddWithValue("@totalQuantity", inventory.TotalQuantity);

                    cmd.Parameters.AddWithValue("@availableQuantity", inventory.AvailableQuantity);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error updating dress inventory: " + ex.Message);
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool UpdateInventoryQuantity(int inventoryId, int quantityChange, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
                UPDATE dress_inventory 
                SET available_quantity = available_quantity + @qtyChange 
                WHERE inventory_id = @id 
                  AND available_quantity >= @checkQty"; 

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@qtyChange", quantityChange);
                cmd.Parameters.AddWithValue("@id", inventoryId);

                cmd.Parameters.AddWithValue("@checkQty", (quantityChange < 0) ? -quantityChange : 0);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}
