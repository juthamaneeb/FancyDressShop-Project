using iTextSharp.text;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FancyDressShop
{
    public class FinancialSummary
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalFines { get; set; }
        public int TotalRentals { get; set; }
    }

    public class TopDressReport
    {
        public string DressName { get; set; }
        public string Category { get; set; }
        public int RentalCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalRentalDays { get; set; }
    }

    public class CategoryRevenueReport
    {
        public string Category { get; set; }
        public int RentalCount { get; set; }
        public decimal TotalRevenue { get; set; } 
    }

    internal class RentalRepository
    {
        private DBConnection dbConnection;
        private readonly DressInventoryRepository _inventoryRepo = new DressInventoryRepository();
        public RentalRepository()
        {
            dbConnection = new DBConnection();
        }

        public int CreateRental(int customerId, DateTime rentalDate, DateTime dueDate, decimal grandTotal, decimal totalDeposit, List<CartItem> cartItems)
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                MessageBox.Show("ตะกร้าว่างเปล่า", "Error");
                return 0;
            }

            DateTime safeRentalDate = rentalDate.Date;
            DateTime safeDueDate = dueDate.Date;
            int rentalId = 0;

            if (dbConnection.OpenConnection())
            {
                MySqlConnection connection = dbConnection.GetConnection();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlRentalInsert = @"
                            INSERT INTO rentals1 
                            (customer_id, rental_date, due_date, total_price, deposit_amount, status, payment_status, creation_time, outstanding_balance) 
                            VALUES (@custId, @rDate, @dDate, @tPrice, @tDeposit, 'Pending Payment', 'Unpaid', NOW(), @outBalance)";

                        MySqlCommand cmdRental = new MySqlCommand(sqlRentalInsert, connection, transaction);

                        cmdRental.Parameters.AddWithValue("@custId", customerId);
                        cmdRental.Parameters.AddWithValue("@rDate", safeRentalDate);
                        cmdRental.Parameters.AddWithValue("@dDate", safeDueDate); 

                        cmdRental.Parameters.AddWithValue("@tPrice", grandTotal);
                        cmdRental.Parameters.AddWithValue("@tDeposit", totalDeposit);
                        cmdRental.Parameters.AddWithValue("@outBalance", 0);
                        cmdRental.ExecuteNonQuery();

                        string sqlGetId = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmdGetId = new MySqlCommand(sqlGetId, connection, transaction);
                        rentalId = Convert.ToInt32(cmdGetId.ExecuteScalar());

                        string detailQuery = @"
                            INSERT INTO rental_details (
                            rental_id, dress_inventory_id, rental_quantity, price_at_rental
                            )
                            VALUES (
                            @rentalId, @inventoryId, @quantity, @price
                            )";

                        foreach (var item in cartItems)
                        {
                            MySqlCommand cmdDetail = new MySqlCommand(detailQuery, connection, transaction);
                            cmdDetail.Parameters.AddWithValue("@rentalId", rentalId);
                            cmdDetail.Parameters.AddWithValue("@inventoryId", item.DressInventoryId);
                            cmdDetail.Parameters.AddWithValue("@quantity", item.Quantity);        
                            cmdDetail.Parameters.AddWithValue("@price", item.RentalPricePerDay);   
                            cmdDetail.ExecuteNonQuery();

                            bool stockUpdated = _inventoryRepo.UpdateInventoryQuantity(
                                item.DressInventoryId,
                                -item.Quantity,
                                connection,
                                transaction
                            );

                            if (!stockUpdated)
                            {
                                throw new Exception($"ไม่สามารถหักสต็อกสำหรับ ID {item.DressInventoryId}. สต็อกไม่พอหรือมีปัญหาการทำรายการ");
                            }
                        }

                        transaction.Commit();
                        return rentalId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error creating rental: " + ex.Message, "Error");
                        return 0;
                    }
                    finally
                    {
                        dbConnection.CloseConnection();
                    }
                }
            }
            return 0;
        }

        public static string ConvertStatusToThai(string englishStatus)
        {
            var statusTranslations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Pending Payment", "รอชำระเงิน" },
                { "Pending Confirmation", "รอการอนุมัติ" },
                { "Confirmed", "ยืนยันการจอง" },
                { "Active", "กำลังใช้งาน" },
                { "Overdue", "เกินกำหนดคืน" },
                { "Returned", "คืนชุดแล้ว" },
                { "Completed", "เสร็จสมบูรณ์" },
                { "Cancelled", "ยกเลิก" },
                { "Closed", "ปิดบัญชีแล้ว" },

                { "Unpaid", "ยังไม่ชำระ" },
                { "Pending", "รอตรวจสอบ" },
                { "Paid", "ชำระแล้ว" },
                { "Rejected", "ถูกปฏิเสธ" },
                { "Refunded", "คืนเงินแล้ว" }
            };

            if (statusTranslations.TryGetValue(englishStatus, out string thaiStatus))
            {
                return thaiStatus;
            }

            return englishStatus;
        }

        public bool ApprovePayment(int rentalId)
        {
            string rentalQuery = @"
            UPDATE rentals1 
            SET 
                status = 'Confirmed',
                payment_status = 'Paid',
                payment_confirmed_date = @ConfirmedDate
            WHERE 
                rental_id = @rentalId 
                AND status = 'Pending Confirmation' 
                AND payment_status = 'Pending'";

            if (dbConnection.OpenConnection())
            {
                MySqlConnection connection = dbConnection.GetConnection();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(rentalQuery, connection, transaction);
                        cmd.Parameters.AddWithValue("@rentalId", rentalId);
                        cmd.Parameters.AddWithValue("@ConfirmedDate", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error approving payment: " + ex.Message, "Error");
                        return false;
                    }
                    finally
                    {
                        dbConnection.CloseConnection();
                    }
                }
            }
            return false;
        }

        public List<RentalDetail> GetRentalDetails(int rentalId, MySqlConnection connection, MySqlTransaction transaction = null)
        {
            List<RentalDetail> details = new List<RentalDetail>();

            string query = @"
                SELECT 
                    rd.rental_detail_id, 
                    rd.rental_id, 
                    rd.dress_inventory_id, 
                    rd.rental_quantity, 
                    rd.price_at_rental,
                    d.rental_price_per_day AS daily_rental_price,
                    d.deposit_price,
                    d.name AS DressName, 
                    i.size AS DressSize
                
                FROM 
                    rental_details rd
                JOIN 
                    dress_inventory i ON rd.dress_inventory_id = i.inventory_id
                JOIN 
                    dresses d ON i.dress_id = d.dress_id
                WHERE 
                    rd.rental_id = @rentalId";

            MySqlCommand cmd = new MySqlCommand(query, connection, transaction);
            cmd.Parameters.AddWithValue("@rentalId", rentalId);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    details.Add(new RentalDetail
                    {
                        RentalDetailId = reader.GetInt32("rental_detail_id"),
                        RentalId = reader.GetInt32("rental_id"),
                        DressInventoryId = reader.GetInt32("dress_inventory_id"),
                        RentalQuantity = reader.GetInt32("rental_quantity"),
                        PriceAtRental = reader.GetDecimal("price_at_rental"),
                        DailyRentalPrice = reader.IsDBNull(reader.GetOrdinal("daily_rental_price")) ? 0m : reader.GetDecimal("daily_rental_price"),
                        DepositPrice = reader.GetDecimal("deposit_price"),
                        DressName = reader.GetString("DressName"),
                        DressSize = reader.GetString("DressSize")
                    });
                }
            }
            return details;
        }

        public bool SubmitPaymentSlip(int rentalId, string slipPath)
        {
            string query = @"
                UPDATE rentals1
                SET 
                    payment_slip_path = @slipPath,
                    status = 'Pending Confirmation',
                    payment_status = 'Pending'
                WHERE 
                    rental_id = @rentalId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@slipPath", slipPath);
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error submitting payment slip: " + ex.Message, "Error");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public Rental GetRentalById(int rentalId)
        {
            Rental rental = null;
            string query = @"
                SELECT
                    r.rental_id, r.customer_id, r.rental_date, r.due_date,
                    r.return_date, r.total_price, r.deposit_amount, r.outstanding_balance,
                    r.status, r.payment_status, r.payment_slip_path, r.fine_slip_path,r.refund_slip_path,
                    r.notes, r.creation_time,
                    r.handover_date, r.payment_confirmed_date, r.finalize_date,
                    c.full_name AS CustomerName
                FROM
                    rentals1 r
                JOIN
                    customers c ON r.customer_id = c.customer_id
                WHERE
                    r.rental_id = @rentalId";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rental = new Rental
                            {
                                RentalId = reader.GetInt32("rental_id"),
                                CustomerId = reader.GetInt32("customer_id"),
                                RentalDate = reader.GetDateTime("rental_date"),
                                DueDate = reader.GetDateTime("due_date"),
                                Status = reader.GetString("status"),
                                PaymentStatus = reader.GetString("payment_status"),
                                TotalPrice = reader.GetDecimal("total_price"),
                                DepositAmount = reader.GetDecimal("deposit_amount"),

                                ReturnDate = reader.IsDBNull(reader.GetOrdinal("return_date")) ? (DateTime?)null : reader.GetDateTime("return_date"),
                                OutstandingBalance = reader.IsDBNull(reader.GetOrdinal("outstanding_balance")) ? (decimal?)null : reader.GetDecimal("outstanding_balance"),
                                PaymentSlipPath = reader.IsDBNull(reader.GetOrdinal("payment_slip_path")) ? null : reader.GetString("payment_slip_path"),
                                FineSlipPath = reader.IsDBNull(reader.GetOrdinal("fine_slip_path")) ? null : reader.GetString("fine_slip_path"),
                                RefundSlipPath = reader.IsDBNull(reader.GetOrdinal("refund_slip_path")) ? null : reader.GetString("refund_slip_path"),

                                Notes = reader.IsDBNull(reader.GetOrdinal("notes")) ? null : reader.GetString("notes"),
                                CreationTime = reader.GetDateTime("creation_time"),
                                CustomerName = reader.GetString("CustomerName"),
                                HandoverDate = reader.IsDBNull(reader.GetOrdinal("handover_date")) ? (DateTime?)null : reader.GetDateTime("handover_date"),
                                PaymentConfirmedDate = reader.IsDBNull(reader.GetOrdinal("payment_confirmed_date")) ? (DateTime?)null : reader.GetDateTime("payment_confirmed_date"),
                                FinalizeDate = reader.IsDBNull(reader.GetOrdinal("finalize_date")) ? (DateTime?)null : reader.GetDateTime("finalize_date"),
                            };
                        }
                        reader.Close();

                        if (rental != null)
                        {
                            rental.Details = GetRentalDetails(rentalId, dbConnection.GetConnection());
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error getting Rental by ID: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return rental;
        }

        public List<Rental> GetAllRentals()
        {
            List<Rental> rentals = new List<Rental>();
            string query = @"
                SELECT
                    r.*,
                    c.full_name AS CustomerName
                FROM
                    rentals1 r
                JOIN
                    customers c ON r.customer_id = c.customer_id";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rental rental = new Rental
                            {
                                RentalId = reader.GetInt32("rental_id"),
                                CustomerId = reader.GetInt32("customer_id"),
                                CustomerName = reader.GetString("CustomerName"),
                                RentalDate = reader.GetDateTime("rental_date"),
                                DueDate = reader.GetDateTime("due_date"),
                                Status = reader.GetString("status"),
                                PaymentStatus = reader.GetString("payment_status"),

                                TotalPrice = reader.GetDecimal("total_price"),
                                DepositAmount = reader.GetDecimal("deposit_amount"),

                                ReturnDate = reader.IsDBNull(reader.GetOrdinal("return_date")) ? (DateTime?)null : reader.GetDateTime("return_date"),
                                OutstandingBalance = reader.IsDBNull(reader.GetOrdinal("outstanding_balance")) ? 0m : reader.GetDecimal("outstanding_balance"),
                                PaymentSlipPath = reader.IsDBNull(reader.GetOrdinal("payment_slip_path")) ? null : reader.GetString("payment_slip_path"),
                                FineSlipPath = reader.IsDBNull(reader.GetOrdinal("fine_slip_path")) ? null : reader.GetString("fine_slip_path"),
                                Notes = reader.IsDBNull(reader.GetOrdinal("notes")) ? null : reader.GetString("notes"),
                                CreationTime = reader.GetDateTime("creation_time"),

                                HandoverDate = reader.IsDBNull(reader.GetOrdinal("handover_date")) ? (DateTime?)null : reader.GetDateTime("handover_date"),
                                PaymentConfirmedDate = reader.IsDBNull(reader.GetOrdinal("payment_confirmed_date")) ? (DateTime?)null : reader.GetDateTime("payment_confirmed_date"),
                                FinalizeDate = reader.IsDBNull(reader.GetOrdinal("finalize_date")) ? (DateTime?)null : reader.GetDateTime("finalize_date"),


                            };
                            rentals.Add(rental);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error getting all rentals: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return rentals;
        }

        public bool RecordReturnAndCalculateFine(int rentalId, DateTime actualReturnDate)
        {
            Rental rental = GetRentalById(rentalId);

            if (rental == null || (rental.Status != "Active" && rental.Status != "Overdue" && rental.Status != "Confirmed"))
            {
                MessageBox.Show("ไม่สามารถรับคืนชุดได้: บิลไม่อยู่ในสถานะที่ถูกต้อง (สถานะปัจจุบัน: " + (rental?.Status ?? "NULL") + ")", "Error");
                return false;
            }

            DateTime dueDateValue = rental.DueDate;

            if (dbConnection.OpenConnection())
            {
                MySqlConnection connection = dbConnection.GetConnection();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        List<RentalDetail> details = GetRentalDetails(rentalId, connection, transaction);

                        decimal fineAmount = 0m;
                        if (actualReturnDate.Date > rental.DueDate.Date)
                        {
                            int lateDays = (int)(actualReturnDate.Date - rental.DueDate.Date).TotalDays;
                            decimal finePercentage = 0.10m;
                            foreach (var detail in details)
                            {
                                fineAmount += lateDays * detail.RentalQuantity * detail.DailyRentalPrice * finePercentage;
                            }
                        }

                        decimal depositAmount = rental.DepositAmount;
                        decimal outstandingBalance = 0;
                        decimal amountToRefund = 0;

                        if (fineAmount > 0)
                        {
                            if (fineAmount <= depositAmount)
                            {
                                amountToRefund = depositAmount - fineAmount;
                                outstandingBalance = 0;
                            }
                            else
                            {
                                amountToRefund = 0;
                                outstandingBalance = fineAmount - depositAmount;
                            }
                        }
                        else
                        {
                            amountToRefund = depositAmount; 
                            outstandingBalance = 0;
                        }

                        string newStatus = (outstandingBalance > 0) ? "Returned" : "Completed";

                        string rentalQuery = @"
                    UPDATE rentals1
                    SET 
                        return_date = @returnDate, 
                        status = @newStatus, 
                        outstanding_balance = @outstandingBalance,
                        notes = CONCAT(COALESCE(notes, ''), @newNote)
                    WHERE rental_id = @rentalId";

                        MySqlCommand cmd = new MySqlCommand(rentalQuery, connection, transaction);
                        cmd.Parameters.AddWithValue("@returnDate", actualReturnDate.Date);
                        cmd.Parameters.AddWithValue("@newStatus", newStatus);
                        cmd.Parameters.AddWithValue("@outstandingBalance", outstandingBalance);

                        string note = $"\n[System] Returned. Fine: {fineAmount:N2}. Deposit: {depositAmount:N2}. Refund due: {amountToRefund:N2}. Outstanding: {outstandingBalance:N2}.";
                        cmd.Parameters.AddWithValue("@newNote", note);

                        cmd.Parameters.AddWithValue("@rentalId", rentalId);
                        cmd.ExecuteNonQuery();


                        foreach (var detail in details)
                        {
                            bool stockRestored = _inventoryRepo.UpdateInventoryQuantity(
                                detail.DressInventoryId,
                                detail.RentalQuantity,
                                connection,
                                transaction
                            );
                            if (!stockRestored)
                            {
                                throw new Exception($"ไม่สามารถคืนสต็อก ID {detail.DressInventoryId} ได้");
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("DB Error recording return and updating inventory: " + ex.Message, "Error");
                        return false;
                    }
                    finally
                    {
                        dbConnection.CloseConnection();
                    }
                }
            }
            return false;
        }

        public bool RejectPayment(int rentalId)
        {
            string sql = @"
                UPDATE rentals1 SET
                    status = 'Pending Payment',
                    payment_status = 'Unpaid',
                    payment_slip_path = NULL
                WHERE 
                    rental_id = @RentalId 
                    AND status = 'Pending Confirmation'
                    AND payment_status = 'Pending'";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error rejecting payment: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool HandOverDress(int rentalId, DateTime handoverDate)
        {
            string rentalQuery = @"
        UPDATE rentals1
        SET 
            status = 'Active',
            handover_date = @HandoverDate
        WHERE 
            rental_id = @rentalId 
            AND status = 'Confirmed' 
            AND payment_status IN ('Paid', 'Deposit Paid', 'Paid Full')";

            if (dbConnection.OpenConnection())
            {
                MySqlConnection connection = dbConnection.GetConnection();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(rentalQuery, connection, transaction);
                        cmd.Parameters.AddWithValue("@rentalId", rentalId);

                        cmd.Parameters.AddWithValue("@HandoverDate", handoverDate);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("บิลไม่อยู่ในสถานะ 'Confirmed' ไม่สามารถมอบชุดได้", "Warning");
                            return false;
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error handing over dress: " + ex.Message, "Error");
                        return false;
                    }
                    finally
                    {
                        dbConnection.CloseConnection();
                    }
                }
            }
            return false;
        }
        private bool CancelRentalAndReturnStock(int rentalId, MySqlTransaction transaction)
        {
            MySqlConnection connection = transaction.Connection;

            List<RentalDetail> details = GetRentalDetails(rentalId, connection, transaction);


            string updateRentalSql = @"
        UPDATE rentals1
        SET 
            status = 'Cancelled',
            payment_status = 'Cancelled',
            notes = CONCAT(COALESCE(notes, ''), '\n[System] Auto-cancelled due to non-payment after 24 hours.')
        WHERE rental_id = @RentalId AND status = 'Pending Payment'";

            MySqlCommand updateCmd = new MySqlCommand(updateRentalSql, connection, transaction);
            updateCmd.Parameters.AddWithValue("@RentalId", rentalId);

            if (updateCmd.ExecuteNonQuery() == 0)
            {
                return true;
            }

            if (details != null && details.Count > 0)
            {
                foreach (var detail in details)
                {
                    bool stockReturned = _inventoryRepo.UpdateInventoryQuantity(
                        detail.DressInventoryId,
                        detail.RentalQuantity, 
                        connection,
                        transaction
                    );

                    if (!stockReturned)
                    {
                        
                        throw new Exception($"Failed to return stock for Inventory ID: {detail.DressInventoryId}");
                    }
                }
            }
            return true;
        }

        public int AutoCancelPendingRentals()
        {
            int hoursToCancel = 24;
            DateTime cutOffTime = DateTime.Now.AddHours(-hoursToCancel);
            int cancelledCount = 0;

            string selectSql = @"
        SELECT rental_id 
        FROM rentals1
        WHERE status = 'Pending Payment'
        AND creation_time < @CutOffTime";

            List<int> rentalIdsToCancel = new List<int>();

            if (dbConnection.OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(selectSql, dbConnection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@CutOffTime", cutOffTime);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentalIdsToCancel.Add(reader.GetInt32("rental_id"));
                        }
                    }
                }
                dbConnection.CloseConnection();

                if (rentalIdsToCancel.Count > 0 && dbConnection.OpenConnection())
                {
                    MySqlConnection connection = dbConnection.GetConnection();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (int rentalId in rentalIdsToCancel)
                            {
                                if (CancelRentalAndReturnStock(rentalId, transaction))
                                {
                                    cancelledCount++;
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Database Error during auto-cancellation and stock return: " + ex.Message, "Error");
                            cancelledCount = 0;
                        }
                        finally
                        {
                            dbConnection.CloseConnection();
                        }
                    }
                }
            }
            return cancelledCount;
        }


        public List<Rental> GetRentalsByCustomerId(int customerId)
        {
            List<Rental> rentals = new List<Rental>();
            string query = @"
                SELECT
                    r.*, 
                    c.full_name AS CustomerName
                FROM
                    rentals1 r
                JOIN
                    customers c ON r.customer_id = c.customer_id
                WHERE
                    r.customer_id = @customerId
                ORDER BY
                    r.creation_time DESC";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rental rental = new Rental
                            {
                                RentalId = reader.GetInt32("rental_id"),
                                CustomerId = reader.GetInt32("customer_id"),
                                RentalDate = reader.GetDateTime("rental_date"),
                                DueDate = reader.GetDateTime("due_date"),
                                Status = reader.GetString("status"),
                                PaymentStatus = reader.GetString("payment_status"),
                                TotalPrice = reader.GetDecimal("total_price"),
                                DepositAmount = reader.GetDecimal("deposit_amount"),

                                ReturnDate = reader.IsDBNull(reader.GetOrdinal("return_date")) ? (DateTime?)null : reader.GetDateTime("return_date"),
                                OutstandingBalance = reader.IsDBNull(reader.GetOrdinal("outstanding_balance")) ? (decimal?)null : reader.GetDecimal("outstanding_balance"),
                                PaymentSlipPath = reader.IsDBNull(reader.GetOrdinal("payment_slip_path")) ? null : reader.GetString("payment_slip_path"),
                                FineSlipPath = reader.IsDBNull(reader.GetOrdinal("fine_slip_path")) ? null : reader.GetString("fine_slip_path"),
                                RefundSlipPath = reader.IsDBNull(reader.GetOrdinal("refund_slip_path")) ? null : reader.GetString("refund_slip_path"),

                                Notes = reader.IsDBNull(reader.GetOrdinal("notes")) ? null : reader.GetString("notes"),
                                CreationTime = reader.GetDateTime("creation_time"),
                                CustomerName = reader.GetString("CustomerName"),
                                HandoverDate = reader.IsDBNull(reader.GetOrdinal("handover_date")) ? (DateTime?)null : reader.GetDateTime("handover_date"),
                                PaymentConfirmedDate = reader.IsDBNull(reader.GetOrdinal("payment_confirmed_date")) ? (DateTime?)null : reader.GetDateTime("payment_confirmed_date"),
                                FinalizeDate = reader.IsDBNull(reader.GetOrdinal("finalize_date")) ? (DateTime?)null : reader.GetDateTime("finalize_date"),
                            };
                            rentals.Add(rental);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error getting customer rentals: " + ex.Message, "Error");
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return rentals;
        }

        public bool SubmitFineSlip(int rentalId, string slipPath)
        {
            string query = @"
                UPDATE rentals1
                SET
                    fine_slip_path = @slipPath
                WHERE 
                    rental_id = @rentalId
                    AND status = 'Returned'
                    AND outstanding_balance > 0";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@slipPath", slipPath);
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error submitting fine slip: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public string GetFirstDressImagePathByRentalId(int rentalId)
        {
            string imagePath = null;
            string query = @"
                SELECT
                    d.image_path
                FROM rental_details rd
                JOIN dress_inventory di ON rd.dress_inventory_id = di.inventory_id
                JOIN dresses d ON di.dress_id = d.dress_id
                WHERE rd.rental_id = @rentalId
                LIMIT 1";

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        imagePath = result.ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("SQL/Database Error fetching dress image path: " + ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("General Error in fetching dress image path: " + ex.Message, "System Error");
                }
            }
            return imagePath;
        }

        public bool CancelRental(int rentalId)
        {
            if (dbConnection.OpenConnection())
            {
                MySqlConnection connection = dbConnection.GetConnection();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        List<RentalDetail> details = GetRentalDetails(rentalId, connection, transaction);

                        string updateRentalSql = @"
                            UPDATE rentals1
                            SET 
                                status = 'Cancelled',
                                payment_status = 'Cancelled',
                                notes = CONCAT(COALESCE(notes, ''), '\n[Customer] Manually cancelled.')
                            WHERE rental_id = @RentalId AND status = 'Pending Payment'";

                        MySqlCommand updateCmd = new MySqlCommand(updateRentalSql, connection, transaction);
                        updateCmd.Parameters.AddWithValue("@RentalId", rentalId);

                        if (updateCmd.ExecuteNonQuery() == 0)
                        {
                            transaction.Rollback();
                            MessageBox.Show("บิลนี้ไม่สามารถยกเลิกได้แล้วเนื่องจากมีการดำเนินการแล้ว", "แจ้งเตือน");
                            return false;
                        }

                        foreach (var detail in details)
                        {
                            bool stockReturned = _inventoryRepo.UpdateInventoryQuantity(
                                detail.DressInventoryId,
                                detail.RentalQuantity,
                                connection,
                                transaction
                            );

                            if (!stockReturned)
                            {
                                throw new Exception($"Failed to return stock for Inventory ID: {detail.DressInventoryId}");
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error during rental cancellation and stock return: " + ex.Message, "Error");
                        return false;
                    }
                    finally
                    {
                        dbConnection.CloseConnection();
                    }
                }
            }
            return false;
        }

        public bool ApproveFinePayment(int rentalId, DateTime finalizeDate)
        {
            string query = @"
                UPDATE rentals1 
                SET 
                    status = 'Completed',
                    payment_status = 'Paid',
                    outstanding_balance = 0,
                    finalize_date = @FinalizeDate -- ⭐️ ใช้ Parameter
                WHERE 
                    rental_id = @rentalId 
                    AND status = 'Returned' 
                    AND outstanding_balance > 0";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);
                    cmd.Parameters.AddWithValue("@FinalizeDate", finalizeDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error approving fine payment: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }

        public bool FinalizeRentalAndRefund(int rentalId, decimal depositAmount, string refundSlipPath)
        {
            string query = @"
                UPDATE rentals1 
                SET 
                    status = 'Closed',
                    payment_status = 'Refunded', 
                    refund_slip_path = @refundSlipPath, 
                    outstanding_balance = 0,
                    finalize_date = NOW()
                WHERE 
                    rental_id = @rentalId 
                    AND status IN ('Completed', 'Returned')";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@rentalId", rentalId);
                    cmd.Parameters.AddWithValue("@refundSlipPath", refundSlipPath);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error finalizing rental: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }


        public List<TopDressReport> GetTopDresses(DateTime startDate, DateTime endDate, int limit = 5)
        {
            var report = new List<TopDressReport>();
            string query = @"
                SELECT 
                    d.name AS DressName,
                    d.category AS Category,
                    COUNT(rd.rental_detail_id) AS RentalCount,
                    COALESCE(SUM(rd.price_at_rental * rd.rental_quantity * (DATEDIFF(r.due_date, r.rental_date))), 0) AS TotalRevenue,
                    COALESCE(SUM(rd.rental_quantity * (DATEDIFF(r.due_date, r.rental_date))), 0) AS TotalRentalDays
                FROM 
                    rental_details rd
                JOIN 
                    rentals1 r ON rd.rental_id = r.rental_id
                JOIN 
                    dress_inventory di ON rd.dress_inventory_id = di.inventory_id
                JOIN 
                    dresses d ON di.dress_id = d.dress_id
                WHERE
                    r.status NOT IN ('Pending Payment', 'Cancelled')
                    AND r.creation_time BETWEEN @startDate AND @endDate
                GROUP BY
                    d.dress_id, d.name, d.category
                ORDER BY
                    RentalCount DESC, TotalRevenue DESC
                LIMIT @limit";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1));
                    cmd.Parameters.AddWithValue("@limit", limit);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            report.Add(new TopDressReport
                            {
                                DressName = reader.GetString("DressName"),
                                Category = reader.GetString("Category"),
                                RentalCount = reader.GetInt32("RentalCount"),
                                TotalRevenue = reader.GetDecimal("TotalRevenue"),
                                TotalRentalDays = reader.GetInt32("TotalRentalDays")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting top dresses report: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return report;
        }

        public FinancialSummary GetFinancialSummary(DateTime startDate, DateTime endDate)
        {
            FinancialSummary summary = new FinancialSummary();
            string query = @"
                SELECT
                    COALESCE(SUM(rd.price_at_rental * rd.rental_quantity * (DATEDIFF(r.due_date, r.rental_date))), 0) AS TotalRevenue,
            
                    COALESCE(SUM(r.outstanding_balance), 0) AS TotalFines,
            
                    COUNT(DISTINCT r.rental_id) AS TotalRentals
                FROM 
                    rental_details rd
                JOIN 
                    rentals1 r ON rd.rental_id = r.rental_id
                WHERE 
                    r.status NOT IN ('Pending Payment', 'Cancelled') 
                    AND r.creation_time BETWEEN @startDate AND @endDate";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            summary.TotalRevenue = reader.GetDecimal("TotalRevenue");
                            summary.TotalFines = reader.GetDecimal("TotalFines");
                            summary.TotalRentals = reader.GetInt32("TotalRentals");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting financial summary: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return summary;
        }

        public List<CategoryRevenueReport> GetCategoryRevenue(DateTime startDate, DateTime endDate)
        {
            var report = new List<CategoryRevenueReport>();

            string query = @"
        SELECT 
            d.category AS Category,
            COUNT(rd.rental_detail_id) AS RentalCount,
            COALESCE(SUM(rd.price_at_rental * rd.rental_quantity * (DATEDIFF(r.due_date, r.rental_date))), 0) AS TotalRevenue
        FROM 
            rental_details rd
        JOIN 
            rentals1 r ON rd.rental_id = r.rental_id
        JOIN 
            dress_inventory di ON rd.dress_inventory_id = di.inventory_id
        JOIN 
            dresses d ON di.dress_id = d.dress_id
        WHERE
            r.status NOT IN ('Pending Payment', 'Cancelled')
            AND r.creation_time BETWEEN @startDate AND @endDate
        GROUP BY
            d.category
        ORDER BY
            TotalRevenue DESC, RentalCount DESC";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date.AddDays(1).AddSeconds(-1));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            report.Add(new CategoryRevenueReport
                            {
                                Category = reader.GetString("Category"),
                                RentalCount = reader.GetInt32("RentalCount"),
                                TotalRevenue = reader.GetDecimal("TotalRevenue")
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting category revenue report: " + ex.Message);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return report;
        }

        public bool RejectFinePayment(int rentalId)
        {
            string sql = @"
                UPDATE rentals1 SET 
                    fine_slip_path = NULL 
                WHERE rental_id = @RentalId 
                AND status = 'Returned'
                AND outstanding_balance > 0";

            if (dbConnection.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, dbConnection.GetConnection());
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Database Error rejecting fine payment: " + ex.Message, "Error");
                    return false;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
            return false;
        }
    }
}
