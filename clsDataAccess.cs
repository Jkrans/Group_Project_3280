using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Group_Project_3280
{
    class clsDataAccess
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string ConnectionString;

        /// <summary>
        /// Constructor that sets the connection string to the database
        /// *** Taken from assignment 6 help examples ***
        /// </summary>
        public clsDataAccess()
        {
            ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + Directory.GetCurrentDirectory() + "\\Invoice.mdb";
        }

        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting values
        /// are returned in a DataSet.  The number of rows returned from the query will be put into
        /// the reference parameter ReturnedValues.
        /// </summary>
        /// <param name="SQL">The SQL statement to be executed.</param>
        /// <param name="ReturnedValues">Reference parameter that returns the number of selected rows.</param>
        /// <returns>Returns a DataSet that contains the data from the SQL statement.</returns>
        public DataSet ExecuteSQLStatement( string SQL, ref int ReturnedValues )
        {
            try
            {
                // Create a new dataset
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(ConnectionString)) // establish connection
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter()) //fill up
                    {
                        // open the connection to the database
                        conn.Open();

                        // add the information for the selectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(SQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        // fill the database with data
                        adapter.Fill(ds);
                    }
                }

                // set the number of values returned
                ReturnedValues = ds.Tables[0].Rows.Count;

                // return the dataset
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statment that is passed in and executes it.  The resulting single 
        /// value is returned.
        /// </summary>
        /// <param name="SQL">The SQL statement to be executed.</param>
        /// <returns>Returns a string from the scalar SQL statement.</returns>
        public string ExecuteScalarSQL( string SQL )
        {
            try
            {
                //Holds the return value
                object obj;

                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(SQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Execute the scalar SQL statement
                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                //See if the object is null
                if (obj == null)
                {
                    //Return a blank
                    return "";
                }
                else
                {
                    //Return the value
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method takes an SQL statment that is a non query and executes it.
        /// </summary>
        /// <param name="sSQL">The SQL statement to be executed.</param>
        /// <returns>Returns the number of rows affected by the SQL statement.</returns>
		public int ExecuteNonQuery( string SQL )
        {
            try
            {
                //Number of rows affected
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    OleDbCommand cmd = new OleDbCommand(SQL, conn);
                    cmd.CommandTimeout = 0;

                    //Execute the non query SQL statement
                    iNumRows = cmd.ExecuteNonQuery();
                }

                //return the number of rows affected
                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }       
    }
}
