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
    /// contains all the business logic for the items window
    /// </summary>
    class clsItemsLogic
    {
        clsItemsSQL isql;
        clsDataAccess da; 
        DataSet ds;

        public clsItemsLogic()
        {
            try
            {
                isql = new clsItemsSQL();
                da = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        public void  DeleteItems(string itemDelete)
        {
            try
            {
                
                string sql = isql.SQLDeleteItem(itemDelete);
                int rowsAffected;
                rowsAffected = da.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
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
        public void updateDesc( string ItemDescription, string cost)
        {
            try
            {
                string sSQL = "ItemDesc = '" + ItemDescription + "', Cost = " + cost + ";";
                string execSQL = isql.SQLupdateItems(sSQL);
                da.ExecuteScalarSQL(execSQL);

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
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
