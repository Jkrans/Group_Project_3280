using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Group_Project_3280.Items
{       

    /// <summary>
    /// contains all the business logic for the items window
    /// </summary>
    class clsItemsLogic
    {
        clsItemsSQL isql;
        clsDataAccess da; 
        DataSet ds;

        private List<Item> Items;
        /// <summary>
        /// constructor
        /// </summary>
        public clsItemsLogic()
        {
            try
            {

                isql = new clsItemsSQL();
                da = new clsDataAccess();

                Items = isql.SQLGetAllitems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Checks if item is on a invoice, if no invoice exists then item is deleted from dataBase
        /// </summary>
        /// <param name="itemDelete"> item object that contains item desc, itemCode, and cost </param>
        public void  DeleteItems(Item itemDelete)
        {
            try
            {

               string invoiceResults;
                string testSQL = isql.SQLSelectItems(itemDelete.Code);
                invoiceResults = da.ExecuteScalarSQL(testSQL);
                
                if (invoiceResults == "")
                { 
                string sql = isql.SQLDeleteItem(itemDelete.Code);
                int rowsAffected;
                rowsAffected = da.ExecuteNonQuery(sql);
                }
                else if (invoiceResults != "")
                {
                    MessageBox.Show("Selected item is on invoice Number " + invoiceResults + ". It cannot be deleted");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// creates and executes a line item update sql Statement
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <param name="LineNumber"></param>
        /// <param name="LineItemCost"></param>
        public void updateLineItems(string InvoiceNumber, string LineNumber, string LineItemCost)
        {
            try { 
                string sSQL = " Cost = " + LineItemCost + " WHERE InvoiceNum = " + InvoiceNumber + " and LineItemNum = " + LineNumber +  " ;";
                string execSQL = isql.SQLupdateLineItems(sSQL);
                da.ExecuteScalarSQL(execSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// updates an items description and cost using a sql Statement generated from user input
        /// </summary>
        /// <param name="newDescription"></param>
        /// <param name="newCost"></param>
        /// <param name="item"></param>
        public void updateDesc(string newDescription, string newCost, Item item)
        {
            try
            {
                string sSQL = "ItemDesc = '" + newDescription + "', Cost = " + newCost + " WHERE ItemCode = '" + item.Code + "';";
                string execSQL = isql.SQLupdateItems(sSQL);
                da.ExecuteScalarSQL(execSQL);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// adds a new item to the ItemDesc Table
        /// </summary>
        /// <param name="ItemDescription"></param>
        /// <param name="ItemCost"></param>
        /// <param name="ItemCode"></param>
        public void addItem(string ItemDescription, string ItemCost, string ItemCode)
        {
            try 
            { 

                string sSQL = "'"+ ItemCode + "', '" + ItemDescription +"', " + ItemCost + ");";
                string execSQL = isql.SQLInsertItem(sSQL);
                da.ExecuteScalarSQL(execSQL);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
