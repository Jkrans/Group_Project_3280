﻿using System;
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
        ///////////////////////////////////
        /// <summary>
        /// Search Logic Object
        /// </summary>
        public clsSearchLogic SearchLogic;

        /// <summary>
        /// Exception handler object
        /// </summary>
        public ExceptionHandler handler;

        /// <summary>
        /// The items that is currently selected.
        /// </summary>
       // private Invoice selectedInvoice;

        private clsDataAccess da;

        /// <summary>
        /// Default constructor
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();
            SearchLogic = new clsSearchLogic();
            handler = new ExceptionHandler();
            da = new clsDataAccess();
            dgInvoice.ItemsSource = SearchLogic.InvoiceList;
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
            update();
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
            //Invoice_Grid.DataSource = SearchLogic.ItemsList;
            //clsSearchSQL.report(selected values); // pass in selected values from comboboxes
            // the DataSet returned from the report()method will be binded to the datagrid
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void update()
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

        private void Invoice_Date_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void Total_Charges_DropBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
    }
}
