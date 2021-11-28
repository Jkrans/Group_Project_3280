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
using System.Windows.Shapes;

namespace Group_Project_3280.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {

        int operationType = 0; 
        public wndItems()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateDescButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDescGrid.Visibility = Visibility.Visible; 
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // clsSQL.update();
        }

        private void UpdateLineItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateLineGrid.Visibility = Visibility.Visible;
           // operationType; 
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemGrid.Visibility = Visibility.Visible;

        }

        private void ItemLineTextBox2_TextChanged( object sender, TextChangedEventArgs e )
        {

        }
    }
}
