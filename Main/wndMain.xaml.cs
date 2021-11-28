using Group_Project_3280.Items;
using Group_Project_3280.Search;
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

namespace Group_Project_3280.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
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
    }
}
