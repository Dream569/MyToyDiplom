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

namespace MyToyDiplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Window
    {
        public BasketPage()
        {
            InitializeComponent();
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress", "Work in progress", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress", "Work in progress", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress", "Work in progress", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
    }
}
