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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Window
    {
        public SupplierPage()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = SuppliersListView.SelectedIndex;
                SuppliersListView.ItemsSource = _db.Suppliers.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == SuppliersListView.Items.Count) selectedIndex--;
                    SuppliersListView.SelectedIndex = selectedIndex;
                    SuppliersListView.ScrollIntoView(SuppliersListView.SelectedItem);
                }
                SuppliersListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Supl = null;
            SupplierAddEdit f = new SupplierAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersListView.SelectedItem != null)
            {
                Data.Supl = (Supplier)SuppliersListView.SelectedItem;
                SupplierAddEdit f = new SupplierAddEdit();
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
                    Supplier row = (Supplier)SuppliersListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Suppliers.Remove(row);
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
            else SuppliersListView.Focus();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
