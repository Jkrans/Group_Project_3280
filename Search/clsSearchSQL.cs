using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Search
{ 
    class clsSearchSQL
    {
        /// <summary>
        /// Data Access Object
        /// </summary>
        clsDataAccess dataAccess;

        /// <summary>
        /// Data Set Object
        /// </summary>
        DataSet ds;

        /// <summary>
        /// Default constructor for Search SQL.
        /// </summary>
        public clsSearchSQL()
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
        public List<Invoice> GetAllInvoices()
        {
            try
            {
                List<Invoice> invoices = new List<Invoice>();

                string sql = "SELECT * FROM Invoices";

                int returnedValue = 0;

                ds = dataAccess.ExecuteSQLStatement(sql, ref returnedValue);

                foreach (DataRow dataRow in ds.Tables[0].Rows) // loop through the data set and add items.
                {
                    invoices.Add(new Invoice(Convert.ToChar(dataRow[0]), dataRow[1].ToString(), Convert.ToDouble(dataRow[2])));
                }

                return invoices;
            }

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        public List<Invoice> GetSelectedIvoices(string num = "", string date = "", string cost = "")
        {
            try 
            { 
                string Num = "", Date = "", Cost = "";
                string sSQL;

                //build the SQL statement based on combo box selections passed
                if (num != "")
                {
                    Num = " Where " + "InvoiceNum = " + num;
                    if ((date != "") && (cost != "")) // if all three parameters are provided
                    {
                        Date = " AND " + "InvoiceDate = " + date;
                        Cost = " AND " + "TotalCost = " + cost;
                    }
                    else if ((date != "") && (cost == "")) // if only num and date are provided
                    {
                        Date = " AND " + "InvoiceDate = " + date;
                    }
                    else if ((date == "") && (cost != ""))// if only num and cost are provided
                    {
                        Cost = " AND " + "TotalCost = " + cost;
                    }
                }
                else if (num == "") // if num is not provided
                {
                    if ((date != "") && (cost != "")) // if date and cost are provided
                    {
                        Date = " Where " + "InvoiceDate = " + date;
                        Cost = " AND " + "TotalCost = " + cost;
                    }
                    else if ((date != "") && (cost == "")) // if only date is provided
                    {
                        Date = " Where " + "InvoiceDate = " + date;
                    }
                    else if ((date == "") && (cost != "")) // if only cost is provided
                    {
                        Cost = " Where " + "TotalCost = " + cost;
                    }
                }
                DateTime enteredDate = DateTime.Parse(Date);
                sSQL = Num + enteredDate + Cost;


                    List<Invoice> SelectedIvoices = new List<Invoice>();
                    string sql = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices " + sSQL;

                    int returnedValue = 0;


                    ds = dataAccess.ExecuteSQLStatement(sql, ref returnedValue);

                    foreach (DataRow dataRow in ds.Tables[0].Rows) // loop through the data set and add items.
                    {
                        SelectedIvoices.Add(new Invoice(Convert.ToChar(dataRow[0]), dataRow[1].ToString(), Convert.ToDouble(dataRow[2])));
                    }

                    return SelectedIvoices;

            }
        

            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);

            }
        }






    }
}
