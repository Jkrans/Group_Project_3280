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

namespace Group_Project_3280.Items
{

     

    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        int operationType = 0;
        clsItemsLogic iLogic;
        clsItemsSQL isql;
        Item item;



        public wndItems()
        {
            InitializeComponent();
            iLogic = new clsItemsLogic();
            isql = new clsItemsSQL();

        }
      /// <summary>
      ///  Deletes the Selected item from the ItemDataBox if no item is selected a error message is shown 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ItemDataGrid.SelectedItem != null)
                    iLogic.DeleteItems(item);
                else
                    MessageBox.Show("An item must be selected before it can be deleted. ");
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

     

        private void UpdateDescButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                    operationType = 1;
                //make all other grids not visible and set updateDesc to visible 
                AddItemGrid.Visibility = Visibility.Hidden;
                    UpdateLineGrid.Visibility = Visibility.Hidden;
                    UpdateDescGrid.Visibility = Visibility.Visible; 
            }
            catch(Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Checks which opertation type is set then does the appropriate logic based on result. if no operation is chosen a message box is shown. 
        /// after operation is complete updates ItemDataGrid to show the current state of the ItemDesc table. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ItemDataGrid.SelectedItem != null || operationType == 3)
                { 

                        switch (operationType)
                    {
                        case 1://update Description
                            iLogic.updateDesc(ItemDescriptionTextBox.Text, ItemCostTextBox.Text,  item);

                            break;
                        case 2: // update Line Item
                            iLogic.updateLineItems(InvoiceNumberTextBox.Text, LineNumberTextBox.Text, LineItemCostTextBox.Text);

                            break;
                        case 3: // add Item

                            iLogic.addItem(AddItemDescriptionTextBox.Text, AddItemCostTextBox.Text, AddItemCodeTextBox.Text);

                            break;
                        case 0:
                            MessageBox.Show("an operation must be selected before a save can be complete. ");
                            break;
                    }
               }
                else
                    MessageBox.Show("An item must be selected before it can changed ");
                ItemDataGrid.ItemsSource = null; 
                ItemDataGrid.ItemsSource = isql.SQLGetAllitems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// sets operation type to 2 
        /// hides all other grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLineItem_Click(object sender, RoutedEventArgs e)
        {
            try {
                operationType = 2; 
                //make all other grids not visible and set updateLine to visible 
                UpdateLineGrid.Visibility = Visibility.Visible;
                AddItemGrid.Visibility = Visibility.Hidden;
                UpdateDescGrid.Visibility = Visibility.Hidden;
                
            }
              catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            // operationType; 
        }
        /// <summary>
        /// sets operation type to 3 
        /// hides all other grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                operationType = 3;
                //make all other grids not visible and set addItemGrid to visible 
                AddItemGrid.Visibility = Visibility.Visible;
                UpdateDescGrid.Visibility = Visibility.Hidden;
                UpdateLineGrid.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

   
        /// <summary>
        /// fills the ItemDataGrid with all the items in the itemDesc table when the item table is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wndItems_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemDataGrid.ItemsSource = isql.SQLGetAllitems();

            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// updates the item object whenever a new selection in the ItemDataGrid is made. also updates teh text of the itemDescriptionTextBox and ItemCostTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ItemDataGrid.SelectedItem != null)
            { 
                item = (Item)ItemDataGrid.SelectedItem;
                ItemDescriptionTextBox.Text = item.Description;
                ItemCostTextBox.Text = Convert.ToString(item.Cost); 
            }
            else
                return;

        }
    }
}
