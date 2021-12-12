using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace Group_Project_3280.Items
{


    /// <summary>
    /// contains all SQL statements for the Items Window
    /// </summary>
    class clsItemsSQL
    {
        clsDataAccess da;
        DataSet ds;
       
        /// <summary>
        /// constructor
        /// </summary>
        public clsItemsSQL() {
            try
            {
                da = new clsDataAccess();
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }
        /// <summary>
        /// Selects items based on the a name entered by user
        /// </summary>
        /// <param name="itemName"> string containing a name for an item</param>
        /// <returns></returns>
        public string SQLSelectItems( string itemName )
        {
            try { 
            string sSQL = "SELECT InvoiceNum FROM LineItems Where ItemCode = '" + itemName + "';";
            return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
       /// <summary>
       /// uses a string input by user to update a entry in the item Table 
       /// </summary>
       /// <param name="itemUpdateSQL"> update entry input by string </param>
       /// <returns></returns>
        public string SQLupdateItems(string itemUpdateSQL)
        {
            try { 
            string sSQL = "UPDATE ItemDesc SET " + itemUpdateSQL;
            return sSQL;
            }
            catch (Exception ex)
             {
              throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
             }
          }

        /// <summary>
        /// updates LineItem From User Input
        /// </summary>
        /// <param name="lineItemUpdateSQL"></param>
        /// <returns></returns>
        public string SQLupdateLineItems(string lineItemUpdateSQL)
        {
            try
            {
                string sSQL = "UPDATE LineItems SET " + lineItemUpdateSQL;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// uses a string input by user to delete from the item Table 
        /// </summary>
        /// <param name="itemDeleteSQL"> string containing when thing should be deleted from item table</param>
        public string SQLDeleteItem(string itemDeleteSQL)
        {
            try
            {
                string sSQL = "DELETE FROM ItemDesc WHERE ItemCode =  " + itemDeleteSQL;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Creates a Sql Statement to insert into ItemDesc from data entered by user. 
        /// </summary>
        /// <param name="insertItemSQL"></param>
        /// <returns></returns>
        public string SQLInsertItem(string insertItemSQL)
        {
            string sSQL = " Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values(" + insertItemSQL;
            return sSQL;
        }
        /// <summary>
        /// gets all enteries in the ItemDesc Table then inserts the results in a list that is then sent to the window to be displayed
        /// </summary>
        /// <returns></returns>
        public List<Item> SQLGetAllitems()
        {
            int iNumRetValues = 0;
            


            List<Item> items = new List<Item>();

            string sSQL = "Select ItemCode, ItemDesc, Cost FROM ItemDesc";

            

            ds = da.ExecuteSQLStatement(sSQL, ref iNumRetValues);

            foreach (DataRow dataRow in ds.Tables[0].Rows) // loop through the data set and add items.
            {
                items.Add(new Item(Convert.ToString(dataRow[0]), dataRow[1].ToString(), Convert.ToDouble(dataRow[2])));
            }

            return items;
        }

        
    }
}
