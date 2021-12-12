using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Main
{
    class clsMainSQL
    {
        
        /// <summary>
        /// Data Access Object
        /// </summary>
        clsDataAccess dataAccess;

        /// <summary>
        /// Data Set Object
        /// </summary>
        DataSet dataSet;

        /// <summary>
        /// Default constructor for Main SQL.
        /// </summary>
        public clsMainSQL()
        {
            try
            {
                dataAccess = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }   

        #region SQL insert queries
        ///<summary>
        ///Insert new Invoice, return its number for displaying
        ///</summary>
        ///<param name="newInvoice">Invoice number</param>
        public int InsertNewInvoice( Invoice newInvoice )
        {
            try
            {
                //Insert new Invoice first
                string sql = "INSERT INTO Invoices(InvoiceDate, TotalCost) VALUES('" + newInvoice.Date + "', '" + newInvoice.Total + "')";

                dataAccess.ExecuteNonQuery(sql);

                //Get that Invoice Number
                sql = "SELECT TOP 1 InvoiceNum FROM Invoices ORDER BY InvoiceNum DESC";
                int retVal = 0;
                dataSet = dataAccess.ExecuteSQLStatement(sql, ref retVal);
                int invoiceNum = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);

                //insert Line items
                int lineItemNumber = 1;
                foreach (Item item in newInvoice.Items)
                {
                    sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES('" + invoiceNum + "', '" + lineItemNumber + "', '" + item.Code + "')";
                    dataAccess.ExecuteNonQuery(sql);
                    lineItemNumber++;

                }

                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion

        #region SQL get queries
        /// <summary>
        /// SQL to get all items.
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItems()
        {
            try
            {
                List<Item> items = new List<Item>();
                
                string sql = "SELECT * FROM ItemDesc";

                int returnedValue = 0;

                dataSet = dataAccess.ExecuteSQLStatement(sql, ref returnedValue);
                
                foreach (DataRow dataRow in dataSet.Tables[0].Rows) // loop through the data set and add items.
                {
                    items.Add(new Item(Convert.ToChar(dataRow[0]), dataRow[1].ToString(), (float)Convert.ToDouble(dataRow[2])));
                }

                return items;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL to get an invoice by ID.
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public Invoice GetInvoiceByID( int invoiceID )
        {
            try
            {                
                string sql = "SELECT * FROM Invoices WHERE InvoiceNum = " + invoiceID;
                Invoice invoice = null;

                int returnedValue = 0;

                dataSet = dataAccess.ExecuteSQLStatement(sql, ref returnedValue);

                DataRow dataRow = dataSet.Tables[0].Rows[0];

                invoice = new Invoice(Convert.ToInt32(dataRow[0]), dataRow[1].ToString(), Convert.ToDouble(dataRow[2]));

                return invoice;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL to get items by invoiceNumber
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public List<Item> GetItemsByInvoiceNum( int invoiceNumber )
        {
            try
            {
                List<Item> items = new List<Item>();
                
                string sql = "SELECT ID.ItemCode, ID.ItemDesc, ID.Cost FROM ITemDesc ID " +
                    "INNER JOIN LineItems LI ON ID.ItemCode = LI.ItemCode " +
                    "WHERE LI.InvoiceNum = " + invoiceNumber;

                int returnedValue = 0;

                dataSet = dataAccess.ExecuteSQLStatement(sql, ref returnedValue);

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    items.Add(new Item(Convert.ToChar(dataRow[0]), dataRow[1].ToString(), (float)Convert.ToDouble(dataRow[2])));
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion        

        #region SQL update queries
        /// <summary>
        /// SQL to Update Invoice Date
        /// updates Invoice Date base on InvoiceNumber
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoiceDate( Invoice invoice )
        {
            try
            {
                string sql = "UPDATE Invoices SET InvoiceDate = #" + invoice.Date + "# WHERE InvoiceNum = " + invoice.Number;
                dataAccess.ExecuteNonQuery(sql);
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL to update invoice items.
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateInvoiceItem( Invoice invoice )
        {
            try
            {                
                // deltes lines first.
                string delete = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.Number;

                dataAccess.ExecuteNonQuery(delete);

                // loop through and add new rows.
                int lineItemNumber = 1;
                foreach (Item item in invoice.Items)
                {
                    string sql = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) VALUES ('"
                        + invoice.Number + "', '" + lineItemNumber + "', '" + item.Code + "')";
                    dataAccess.ExecuteNonQuery(sql);
                    lineItemNumber++;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion

        #region SQL delete queries

        /// <summary>
        /// SQL to delete an Invoice from both tables.
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice( Invoice invoice )
        {
            try
            {
                //need to delete from Line Items first                
                string sql = "DELETE FROM LineItems WHERE InvoiceNum = " + invoice.Number;
                dataAccess.ExecuteNonQuery(sql);

                //delete from Invoices
                sql = "DELETE FROM Invoices WHERE InvoiceNum = " + invoice.Number;
                dataAccess.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        #endregion        
    }
}
