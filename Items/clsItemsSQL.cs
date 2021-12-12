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
        public string SQLSelectItems( string itemName)
        {
            try { 
            string sSQL = "SELECT * FROM Items Where ItemName = " + itemName;
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
            string sSQL = "UPDATE item SET " + itemUpdateSQL;
            return sSQL;
            }
            catch (Exception ex)
             {
              throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
             }
          }


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
                string sSQL = "DELETE FROM item WHERE itemName =  " + itemDeleteSQL;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        public string SQLInsertItem(string insertItemSQL)
        {
            string sSQL = " Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values('" + insertItemSQL;
            return sSQL;
        }

        public DataSet SQLDisplayItems()
        {
            int iNumRetValues = 0;
            DataSet ds;
            string sSQL = "Select * FROM items";
            ds = da.ExecuteSQLStatement(sSQL, ref iNumRetValues);
            return ds;
        }

        
    }
}
