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
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Window
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = CategoriesListView.SelectedIndex;
                CategoriesListView.ItemsSource = _db.Categories.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == CategoriesListView.Items.Count) selectedIndex--;
                    CategoriesListView.SelectedIndex = selectedIndex;
                    CategoriesListView.ScrollIntoView(CategoriesListView.SelectedItem);
                }
                CategoriesListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Cater = null;
            CategoryAddEdit f = new CategoryAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesListView.SelectedItem != null)
            {
                Data.Cater = (Category)CategoriesListView.SelectedItem;
                CategoryAddEdit f = new CategoryAddEdit();
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
                    Category row = (Category)CategoriesListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Categories.Remove(row);
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
            else CategoriesListView.Focus();
        }
        private void categoryPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
