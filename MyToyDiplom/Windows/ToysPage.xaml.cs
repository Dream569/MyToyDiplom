using MyToyDiplom.DataBase;
using MyToyDiplom.WindowAddEditPage;
using System;
using System.Collections;
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
    /// Логика взаимодействия для ToysPage.xaml
    /// </summary>
    public partial class ToysPage
    {
        public ToysPage()
        {
            InitializeComponent();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            if (Data.Right == "Buyer")
            {
                AddTov.IsEnabled = false;
                EdTov.IsEnabled = false;
                DelTov.IsEnabled = false;
                AddTov.Opacity = 0.0;
                EdTov.Opacity = 0.0;
                DelTov.Opacity = 0.0;

            }
            else
            if (Data.Right == "Admin" || Data.Right == "Employee")
            {

            }
            else
            {
                AddTov.IsEnabled = false;
                EdTov.IsEnabled = false;
                DelTov.IsEnabled = false;
                AddTov.Opacity = 0.0;
                EdTov.Opacity = 0.0;
                DelTov.Opacity = 0.0;
            }
            Title = Title + " " + Data.UserSurname + " " + Data.UserName + " (" + Data.Right + ")";
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = ProductsListView.SelectedIndex;
                ProductsListView.ItemsSource = _db.Toys.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == ProductsListView.Items.Count) selectedIndex--;
                    ProductsListView.SelectedIndex = selectedIndex;
                    ProductsListView.ScrollIntoView(ProductsListView.SelectedItem);
                }
                ProductsListView.Focus();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Toy = null;
            AddEditPage f = new AddEditPage();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsListView.SelectedItem != null)
            {
                Data.Toy = (Toy)ProductsListView.SelectedItem;
                AddEditPage f = new AddEditPage();
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
                    Toy row = (Toy)ProductsListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Toys.Remove(row);
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
            else ProductsListView.Focus();
        }
        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress", "Work in progress", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
        private void ResetFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in progress", "Work in progress", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
    }
}
