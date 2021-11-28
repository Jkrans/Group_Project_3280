using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Items
{


    /// <summary>
    /// contains all SQL statements for the Items Window
    /// </summary>
    class clsItemsSQL
    {

        public clsItemsSQL() { 
         
        }
        /// <summary>
        /// Selects items based on the a name entered by user
        /// </summary>
        /// <param name="itemName"> string containing a name for an item</param>
        /// <returns></returns>
        public string SQLSelectItems( string itemName)
        {

            string sSQL = "SELECT * FROM Items Where ItemName = " + itemName;
            return sSQL;

        }
       /// <summary>
       /// uses a string input by user to update a entry in the item Table 
       /// </summary>
       /// <param name="itemUpdateSQL"> update entry input by string </param>
       /// <returns></returns>
        public string SQLupdateItems(string itemUpdateSQL)
        {

            string sSQL = "UPDATE item SET " + itemUpdateSQL;
            return sSQL; 
        }
        /// <summary>
        /// uses a string input by user to delete from the item Table 
        /// </summary>
        /// <param name="itemDeleteSQL"> string containing when thing should be deleted from item table</param>
        public string SQLDeleteItem(string itemDeleteSQL)
        {
            string sSQL = "DELETE FROM item WHERE itemName =  " + itemDeleteSQL;
            return sSQL; 
        }

    }
}
