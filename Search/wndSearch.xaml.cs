using Group_Project_3280.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        ///////////////////////////////////
        /// <summary>
        /// Search Logic Object
        /// </summary>
        private clsSearchLogic SearchLogic;

        /// <summary>
        /// Exception handler object
        /// </summary>
        private ExceptionHandler handler;

        /// <summary>
        /// The items that is currently selected.
        /// </summary>
        public Invoice selectedInvoice;

        private clsDataAccess da;

        /// <summary>
        /// Default constructor
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();
                SearchLogic = new clsSearchLogic();
                handler = new ExceptionHandler();
                da = new clsDataAccess();
                dgInvoice.ItemsSource = SearchLogic.InvoiceList;
                build();
                /*for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
                {
                    Invoice_Number_DropBx.Items.Add(SearchLogic.InvoiceList[i].Number);
                }
                for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
                {
                    Invoice_Date_DropBx.Items.Add(SearchLogic.InvoiceList[i].Date);
                }
                for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
                {
                    Total_Charges_DropBx.Items.Add(SearchLogic.InvoiceList[i].Total);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }

        }

        private void build()
        {
            for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
            {
                Invoice_Number_DropBx.Items.Add(SearchLogic.InvoiceList[i].Number);
            }
            for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
            {
                Invoice_Date_DropBx.Items.Add(SearchLogic.InvoiceList[i].Date);
            }
            for (int i = 0; i < SearchLogic.InvoiceList.Count(); i++)
            {
                Total_Charges_DropBx.Items.Add(SearchLogic.InvoiceList[i].Total);
            }
        }

        /// <summary>
        /// selects the database item from the databox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Invoice_Number_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        /// <summary>
        /// calls the report method to build a 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //open the selected invoice up for viewing on the main screen
                this.Hide();// closes wndSearch
                wndMain wndMain = new wndMain(SearchLogic.sendInv(dgInvoice.SelectedItem));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// reset the form to its initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearSelection_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //reset the form to the inital state.
                Invoice_Number_DropBx.Items.Clear();
                Invoice_Date_DropBx.Items.Clear();
                Total_Charges_DropBx.Items.Clear();
                build();
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Populates the datagrid based on the combo box selections
        /// </summary>
        private void update()
        {
            try
            {
                string num = "", date = "", cost = "";

                if (Invoice_Number_DropBx.SelectedItem != null)
                {
                    num = Invoice_Number_DropBx.SelectedItem.ToString();
                }
                if (Invoice_Date_DropBx.SelectedItem != null)
                {
                    date = Invoice_Date_DropBx.SelectedItem.ToString();
                   
                }
                if (Total_Charges_DropBx.SelectedItem != null)
                {
                    cost = Total_Charges_DropBx.SelectedItem.ToString();
                }

                SearchLogic.Search(num, date, cost);

                dgInvoice.ItemsSource = SearchLogic.SelInvoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        private void Invoice_Date_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void Total_Charges_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }


        private void dgInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                       
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();// closes wndSearch
        }
    }
}
