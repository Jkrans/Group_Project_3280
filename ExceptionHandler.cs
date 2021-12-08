using System;
using System.Windows;

namespace Group_Project_3280 
{
    /// <summary>
    /// Class for handling top level error. Taken from Chapter 13 examples.
    /// </summary>
    public class ExceptionHandler
    {

        #region methods

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        public void HandleError( string sClass, string sMethod, string sMessage )
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        #endregion
    }
}
