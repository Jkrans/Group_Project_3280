using Group_Project_3280.Items;
using Group_Project_3280.Search;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Group_Project_3280.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// Main Logic Object
        /// </summary>
        private clsMainLogic mainLogic;

        /// <summary>
        /// Exception handler object
        /// </summary>
        private ExceptionHandler handler;

        /// <summary>
        /// The items that is currently selected.
        /// </summary>
        private Item selectedItem;

        private clsDataAccess da;

        /// <summary>
        /// Default constructor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();
            mainLogic = new clsMainLogic();
            handler = new ExceptionHandler();
            da = new clsDataAccess();
        }

        /// <summary>
        /// Open Search window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSearchInvoice_Click( object sender, RoutedEventArgs e )
        {
            wndSearch Search = new wndSearch();
            Search.ShowDialog();
        }

        /// <summary>
        /// Open Item List window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemListMenu_Click( object sender, RoutedEventArgs e )
        {
            wndItems Items = new wndItems();
            Items.ShowDialog();
        }

        /// <summary>
        /// Enables functionality to add a new invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInvoice_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                btnAddInvoice.IsEnabled = false;

                lbItems.IsEnabled = true;

                cbItems.IsEnabled = true;
                cbItems.ItemsSource = mainLogic.ItemsList;
                cbItems.DisplayMemberPath = "Description";

                mainLogic.CreateInvoice();
            }

            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables functionality to edit an invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                btnAddInvoice.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;
                btnEditInvoice.IsEnabled = false;

                lbItems.IsEnabled = true;
                lbItems.ItemsSource = mainLogic.CurrentInvoice.Items.ToList();

                cbItems.IsEnabled = true;
                cbItems.ItemsSource = mainLogic.ItemsList;
                cbItems.DisplayMemberPath = "Description";             

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the selected invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteInvoice_Click( object sender, RoutedEventArgs e )
        {
            try
            {           
                MessageBoxResult confirmDeleteInvoice = MessageBox.Show("Are you sure you want to delete this invoice?",
                                            $"Delete Invoice: #{mainLogic.CurrentInvoice.Number}", MessageBoxButton.YesNo);

                if (confirmDeleteInvoice == MessageBoxResult.Yes)
                {
                    mainLogic.DeleteInvoice();

                    lblInvoiceTotal.Content = "";
                    lblInvoiceNumber.Content = "";

                    btnDeleteInvoice.IsEnabled = false;
                    btnAddInvoice.IsEnabled = true;
                    btnEditInvoice.IsEnabled = false;

                    mainLogic.CurrentInvoice = null;

                    lbItems.ItemsSource = null;
                    lbItems.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Shows list of items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbItems_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {

                //need to check for selection being -1
                if (((ComboBox)sender).SelectedIndex == -1)
                {
                    tbQuantity.IsEnabled = false;
                    btnAddItem.IsEnabled = false;
                    return;
                }
                else
                {
                    selectedItem = (Item)cbItems.SelectedItem;
                if (!tbQuantity.IsEnabled)
                {
                    tbQuantity.IsEnabled = true;
                }
                if (!btnAddItem.IsEnabled)
                {
                    btnAddItem.IsEnabled = true;
                }

                tbQuantity.Text = "1";
                lblPrice.Content = selectedItem.Cost.ToString();
                    


               }
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Adds an item to the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                bool isValidQuantity = int.TryParse(tbQuantity.Text, out int quantity);
                if (isValidQuantity && quantity > 0)
                {
                    mainLogic.AddItem(selectedItem, quantity);
                }

                tbQuantity.Text = "0";
                lblPrice.Content = "0";
                lblInvoiceTotal.Content = mainLogic.CurrentInvoice.Total.ToString();
                cbItems.SelectedIndex = -1;

                lbItems.ItemsSource = mainLogic.CurrentInvoice.Items.ToList();

                btnSaveInvoice.IsEnabled = true;

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes item from the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                if (lbItems.SelectedIndex == -1)
                {
                    return;
                }
                selectedItem = (Item)lbItems.SelectedItem;

                

                lblInvoiceTotal.Content = "";
                mainLogic.DeleteItem(selectedItem);
                lbItems.ItemsSource = mainLogic.CurrentInvoice.Items.ToList();
                lblInvoiceTotal.Content = mainLogic.CurrentInvoice.Total.ToString();
                btnDeleteItem.IsEnabled = false;

                btnSaveInvoice.IsEnabled = true;

            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Saves the new invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                string date = tbDate.Text;
                mainLogic.SaveInvoice(date);
                tbDate.IsEnabled = false;

                tbDate.Text = mainLogic.CurrentInvoice.Date.ToString();

                lblInvoiceNumber.Content = mainLogic.CurrentInvoice.Number.ToString();

                btnDeleteInvoice.IsEnabled = true;
                btnEditInvoice.IsEnabled = true;
                btnAddInvoice.IsEnabled = true;

                lblPrice.Content = "$0.00";
                tbQuantity.Text = "0";
                cbItems.IsEnabled = false;
                cbItems.SelectedIndex = -1;
                btnSaveInvoice.IsEnabled = false;
                lbItems.IsEnabled = false;


            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Selects item and enables the delete button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbItems_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {
                ListBox listBoxItem = (ListBox)sender;
                btnDeleteItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                handler.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
    
}
