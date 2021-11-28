using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Search
{
    public static class clsSearchSQL
    {
        ///////////////////////////////////////////////////////////////////////
        //clsDataAccess db; need to add Database class
        //db = new claDataAccess(); need to add Database class
        //////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        /// <summary>
        /// executes SQL statement to return full invoice database
        /// </summary>
        /// <returns>DataSet of full table</returns>
        /*public static DataSet FullData()
        {
            int iNumRetValues = 0;
            DataSet ds;
            string sSQL = "Select * FROM Invoices";
            ds = db.ExecueteSQLStatement(sSQL, ref iNumRetValues);
            return ds;

        }*/
        ///////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////
        /// <summary>
        /// executes SQL statement to return only the requested data based on passed parameters
        /// </summary>
        /// <returns>DataSet of of only requested data</returns>
        /*public static DataSet report(int InvNum, string date, int Charges)
        {
            string invNum = InvNum.ToString();
            string charges = Charges.ToString();
            DataSet ds;
            string sSQL = "Select......."; // build a string to generate a SQL statement using passed in parameters
            ds = db.ExecueteSQLStatement(sSQL, ref iNumRetValues);
            return ds;

        }*/

    }
}
