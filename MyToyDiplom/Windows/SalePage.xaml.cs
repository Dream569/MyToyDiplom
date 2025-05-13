using MyToyDiplom.DataBase;
using MyToyDiplom.WindowAddEditPage;
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
    /// Логика взаимодействия для SalePage.xaml
    /// </summary>
    public partial class SalePage : Window
    {
        public SalePage()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = SalesListView.SelectedIndex;
                SalesListView.ItemsSource = _db.Sales.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == SalesListView.Items.Count) selectedIndex--;
                    SalesListView.SelectedIndex = selectedIndex;
                    SalesListView.ScrollIntoView(SalesListView.SelectedItem);
                }
                SalesListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Sal = null;
            SaleAddEdit f = new SaleAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalesListView.SelectedItem != null)
            {
                Data.Sal = (Sale)SalesListView.SelectedItem;
                SaleAddEdit f = new SaleAddEdit();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIListView();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Sale row = (Sale)SalesListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Sales.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else SalesListView.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
