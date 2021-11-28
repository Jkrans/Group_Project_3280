using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Search
{
    public static class clsSearchLogic
    {
        ////////////////////////////////////////////////////////////////////
        /// <summary>
        /// the business logic to populate the datagrid with invoices
        /// </summary>
        /// <returns>BindingList<clsInvoices></returns>
        /*public static BindingList<clsInvoices> dataGridAll()
        {
            //write code to build a Binding list
            //fucntion to call a SQL statment
            DataSet ds;
            ds = FullData(); // gets the database from the SQL executing funtion Fulldata()


            //add the ds DataSet to the binding list

            //bind binding list to the datagrid in wndSearch
        }*/
        ////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// the business logic to populate the combobox Invoice_Number_DropBx with invoice numbers
        /// </summary>
        /*public static void invoices()
        {
            DataSet ds = dataGridAll(); 
            //bind just the invoice numbers to combobox Invoice_Number_DropBx
        }*/
        /////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// the business logic to populate the combobox Invoice_Date_DropBx with invoice dates
        /// </summary>
        /*public static void invoiceDates()
        {
            DataSet ds = dataGridAll(); 
            //bind just the invoice dates to combobox Invoice_Date_DropBx
        }*/
        /////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// the business logic to populate the combobox Total_Charges_DropBx with invoice charges
        /// </summary>
        /*public static void invoiceCharges()
        {
            DataSet ds = dataGridAll(); 
            //bind just the invoice dates to combobox Invoice_Date_DropBx
        }*/
        /////////////////////////////////////////////////////////////////
    }
}
