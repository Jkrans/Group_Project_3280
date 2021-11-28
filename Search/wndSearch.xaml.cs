using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Group_Project_3280.Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        public wndSearch()
        {
            InitializeComponent();
            ////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// call function to populate the data grid of all invoices from the database.
            /// </summary>
            //clsSearchLogic.dataGridAll()
            ////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// call function to populate the combobox Invoice_Number_DropBx of all invoice number from the database.
            /// </summary>
            //clsSearchLogic.invoices()
            ///////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// call function to populate the combobox Invoice_Date_DropBx of all invoice dates from the database.
            /// </summary>
            //clsSearchLogic.invoiceDates()
            ///////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// call function to populate the combobox Total_Charges_DropBx of all invoice charges from the database.
            /// </summary>
            //clsSearchLogic.invoiceCharges()
            ///////////////////////////////////////////////////////////////////////////
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// selects the database item from the databox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Number_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //(clsInvoices)Invoice_Number_DropBx.SelectedItem.ToString();
        }

        /// <summary>
        /// calls the report method to build a 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            //open the selected invoice up for viewing on the main screen
            this.Hide();// closes wndSearch

        }

        /// <summary>
        /// reset the form to its initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearSelection_Btn_Click(object sender, RoutedEventArgs e)
        {
            //reset the form to the inital state.
        }

        private void Search_Btn_Click(object sender, RoutedEventArgs e)
        {
            //clsSearchSQL.report(selected values); // pass in selected values from comboboxes
            // the DataSet returned from the report()method will be binded to the datagrid
        }
    }
}
